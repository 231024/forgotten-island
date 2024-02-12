using UnityEngine;

public class MenuController : MonoBehaviour
{
	[SerializeField] private ShopController _shop;
	[SerializeField] private Cabin _cabin;

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
		Instantiate(_shop, transform);
	}
}
