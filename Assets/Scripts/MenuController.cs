using UnityEngine;

public class MenuController : MonoBehaviour
{
	[SerializeField] private ShopPresenter _shop;
	[SerializeField] private ShopView _view;
	[SerializeField] private Cabin _cabin;
	[SerializeField] private UnitFactory _factory;

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
		Instantiate(_shop, transform).Inject(_factory);
	}
}
