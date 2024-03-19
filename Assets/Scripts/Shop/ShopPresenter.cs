using System;
using UnityEngine;
using Wallet;

public class ShopPresenter : MonoBehaviour
{
	private const int ItemPrice = 20;
	private const int VillageCapacity = 20;
	[SerializeField] private ShopView _view;

	private UnitFactory _factory;

	private ShopModel _shopModel;
	private WalletPresenter _walletPresenter;

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

	public event Action<string> ItemBought;

	public void Inject(UnitFactory factory)
	{
		_factory = factory;
	}

	public void Inject(WalletPresenter walletPresenter)
	{
		_walletPresenter = walletPresenter;
	}

	private void ModelOnDataChanged()
	{
		_view.Refresh(_shopModel);
	}

	private void OnItemBought(string id)
	{
		if (!_factory.CheckSpaceForId(_shopModel.VillageCapacity, id))
		{
			return;
		}

		if (!_walletPresenter.TryWithdrawGold(ItemPrice))
		{
			return;
		}

		var product = _factory.GetProduct(id);
		_shopModel.VillageCapacity -= product.Weight;

		Debug.Log(_shopModel.VillageCapacity);
	}

	private void OnViewCloseButtonClicked()
	{
		Destroy(_view.gameObject);
	}
}