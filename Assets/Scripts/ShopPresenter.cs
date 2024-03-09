using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopPresenter : MonoBehaviour
{
	[SerializeField] private ShopView _view;

	private UnitFactory _factory;

	private ShopModel _model;

	private void Start()
	{

		_model = new ShopModel(100, _factory.Pools, 20);

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
		if(_factory.CheckSpaceForId(_model.VillageCapacity, id))
		{
			var product = _factory.GetProduct(id);
			_model.VillageCapacity -= product.Weight;
			Debug.Log(_model.VillageCapacity);
			_model.Gold -= 20;
		}
		
	}

	private void OnViewCloseButtonClicked()
	{
		Destroy(_view.gameObject);
	}
}
