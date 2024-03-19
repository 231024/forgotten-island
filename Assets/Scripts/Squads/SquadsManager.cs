using System;
using System.Collections.Generic;
using Clipboard;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public abstract class SquadsManager : IInitializable, ITickable, IDisposable
{
	private readonly Ground[] _grounds;
	private readonly Dictionary<string, List<IProduct>> _squads = new();
	private readonly Tree[] _trees;

	[Inject] private ClipboardPresenter _clipboard;

	private List<IProduct> _currentSquad = new();
	[Inject] private SignalBus _signalBus;

	public SquadsManager()
	{
		UnitPool.EventInstantiate += OnEventInstantiate;

		_grounds = Object.FindObjectsOfType<Ground>();
		_trees = Object.FindObjectsOfType<Tree>();

		foreach (var ground in _grounds)
		{
			ground.GroundTouched += MoveTo;
		}

		foreach (var tree in _trees)
		{
			tree.TreeTouched += MoveTo;
		}
	}

	public string[] KeysArray => new List<string>(_squads.Keys).ToArray();

	public void Dispose()
	{
	}

	public void Initialize()
	{
	}

	public void Tick()
	{
		Debug.Log("Manager");
	}

	private void MoveTo(Vector3 pos)
	{
		foreach (var unit in _currentSquad)
		{
			unit.MoveTo(pos);
		}
	}

	private void OnEventInstantiate(string id, IProduct product)
	{
		if (!_squads.ContainsKey(id))
		{
			var list = new List<IProduct> { product };
			_squads.Add(id, list);

			_signalBus.Fire(new NewSquadMemberAddedSignal());
		}
		else
		{
			if (_squads[id].Contains(product))
			{
				return;
			}

			_squads[id].Add(product);

			_signalBus.Fire(new NewSquadMemberAddedSignal());
		}
	}

	public void PickSquad(string id)
	{
		_clipboard.SetText($"Squad of {id} was picked");
		_currentSquad = _squads[id];
	}
}
