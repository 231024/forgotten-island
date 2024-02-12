using UnityEngine;

public class ShopController : MonoBehaviour
{
	[SerializeField] private ShopItem _initialItem;
	[SerializeField] private RectTransform _parent;
	[SerializeField] private Pooler _pooler;
	[SerializeField] private Factory _factory;

	public void Start()
	{
		foreach (var unit in _pooler.Units)
		{
			var item = Instantiate(_initialItem, _parent);
			item.gameObject.SetActive(true);
			item.SetId(unit.ID);
			item.SetPrice(unit.Price.ToString());
			item.SetCallback(OnItemBought);
		}
	}

	private void OnItemBought(string id)
	{
		_factory.GetProduct(id);
	}

	public void OnCloseButtonClick()
	{
		Destroy(gameObject);
	}
}
