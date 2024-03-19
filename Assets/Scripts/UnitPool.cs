using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

public class UnitPool
{
	private readonly ObjectPool<IProduct> _pool;
	private readonly Unit _prefab;
	private readonly int _weight;
	private readonly string _id;
	private Sprite _sprite;

	public UnitPool(string id, Unit prefab, Sprite sprite, int weight)
	{
		_id = id;
		_prefab = prefab;
		_sprite = sprite;
		_weight = weight;
		_pool = new ObjectPool<IProduct>(Create, Get, Release, Destroy);
	}

	public Sprite Avatar
	{
		get => _sprite;
		set
		{
			if (_sprite == value)
			{
				return;
			}

			_sprite = value;
		}
	}

	public static event Action<string, IProduct> EventInstantiate;

	private void Destroy(IProduct obj)
	{
		Object.Destroy(obj.GO);
	}

	public void Release(IProduct obj)
	{
		obj.GO.SetActive(false);
	}

	private void Get(IProduct obj)
	{
		obj.GO.transform.position = Vector3.zero;
		obj.GO.SetActive(true);
		EventInstantiate?.Invoke(_id, obj);
	}

	private IProduct Create()
	{
		var warrior = Object.Instantiate(_prefab);
		warrior.SetWeight(_weight);
		return warrior;
	}

	public IProduct Get()
	{
		return _pool.Get();
	}
}