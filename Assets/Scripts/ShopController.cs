using UnityEngine;

public class ShopController : MonoBehaviour
{
	[SerializeField] private ShopItem _initialItem;
	[SerializeField] private RectTransform _parent;
	[SerializeField] private ShopUnitList _list;
	[SerializeField] private Player _player;

	public void Start()
	{
		foreach (var unit in _list.Units)
		{
			var item = Instantiate(_initialItem, _parent);
			item.gameObject.SetActive(true);
			item.SetPrice(unit.Price.ToString());
			item.SetCallback(OnItemBought);
		}
	}

	private void OnItemBought()
	{
		Instantiate(_player);
	}

	public void OnCloseButtonClick()
	{
		Destroy(gameObject);
	}
}
