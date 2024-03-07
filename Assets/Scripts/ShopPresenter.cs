using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopPresenter : MonoBehaviour
{
	[SerializeField] private ShopView _view;

	private UnitFactory _factory;

	private ShopModel _model;

	private void Start()
	{


		List<string> _warriorKinds = new List<string>();

		foreach(string key in _factory.Pools.Keys)
			{
				_warriorKinds.Add(key);
			}

		_model = new ShopModel(100, _factory.Pools.Count, _warriorKinds);
		// _model = new ShopModel(100, _factory.Pools.Count, _factory.Pools);

		_model.DataChanged += ModelOnDataChanged;

		_view.Refresh(_model);

		_view.CloseButtonClicked += OnViewCloseButtonClicked;
		_view.ItemBought += OnItemBought;
	}

	private void OnDestroy()
	{
		_view.CloseButtonClicked -= OnViewCloseButtonClicked;
		_view.ItemBought -= OnItemBought;
	}

	public void Inject(UnitFactory factory)
	{
		_factory = factory;
	}

	private void ModelOnDataChanged()
	{
		_view.Refresh(_model);
	}

	public event Action<string> ItemBought;

	private void OnItemBought(string id)
	{
		_factory.GetProduct(id);

		// _model.WarriorCount--;
		_model.Gold -= 20;
	}

	private void OnViewCloseButtonClicked()
	{
		Destroy(_view.gameObject);
	}
}
