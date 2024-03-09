using System;
using UnityEngine;

public class ShopPresenter : MonoBehaviour
{
	[SerializeField] private ShopView _view;

	private UnitFactory _factory;
	private WalletPresenter _walletPresenter;

	private ShopModel _shopModel;

	private const int ItemPrice = 20;
	private const int VillageCapacity = 20;

	public event Action<string> ItemBought;

	private void Start()
	{
		_shopModel = new ShopModel(_factory.Pools, VillageCapacity);
		_shopModel.DataChanged += ModelOnDataChanged;

		_view.Refresh(_shopModel);

		_view.CloseButtonClicked += OnViewCloseButtonClicked;
		_view.ItemBought += OnItemBought;
	}

	private void OnDestroy()
	{
		_view.CloseButtonClicked -= OnViewCloseButtonClicked;
		_view.ItemBought -= OnItemBought;
	}

	public void Inject(UnitFactory factory) =>
		_factory = factory;

	public void Inject(WalletPresenter walletPresenter) =>
		_walletPresenter = walletPresenter;

	private void ModelOnDataChanged()
	{
		_view.Refresh(_shopModel);
	}

	private void OnItemBought(string id)
	{
		if (!_factory.CheckSpaceForId(_shopModel.VillageCapacity, id))
			return;

		if (!_walletPresenter.WithdrawGold(ItemPrice))
			return;

		var product = _factory.GetProduct(id);
		_shopModel.VillageCapacity -= product.Weight;

		Debug.Log(_shopModel.VillageCapacity);
	}

	private void OnViewCloseButtonClicked()
	{
		Destroy(_view.gameObject);
	}
}