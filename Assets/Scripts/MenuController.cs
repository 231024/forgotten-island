using UnityEngine;

public class MenuController : MonoBehaviour
{
	[SerializeField] private ShopPresenter _shop;
	[SerializeField] private Cabin _cabin;
	[SerializeField] private UnitFactory _factory;

	private ShopPresenter _shopPresenter;

	private void Awake()
	{
		_cabin.Touched += OnCabinTouched;
	}

	private void OnDestroy()
	{
		_cabin.Touched -= OnCabinTouched;
	}

	private void OnCabinTouched()
	{
		if (_shopPresenter != null)
			return;

		_shopPresenter = Instantiate(_shop, transform);
		_shopPresenter.Inject(_factory);
	}
}