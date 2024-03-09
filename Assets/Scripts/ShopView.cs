using System;
using UnityEngine;

public class ShopView : MonoBehaviour
{
	[SerializeField] private ShopItem _initialItem;
	[SerializeField] private RectTransform _parent;

	public void Refresh(ShopModel model)
	{

		for (var i = 0; i < _parent.childCount; i++)
		{
			var element = _parent.GetChild(i);
			if (element.gameObject.activeSelf)
			{
				Destroy(element.gameObject);
			}
		}

		foreach (var pool in model.WarriorPools)
		{
			var item = Instantiate(_initialItem, _parent);
			item.gameObject.SetActive(true);
			item.SetId(pool.Key);
			item.SetBuyButtonText(pool.Key);
			item.SetImage(pool.Value.Avatar);

			item.SetCallback(OnItemBought);
		}
	}

	public event Action CloseButtonClicked;
	public event Action<string> ItemBought;

	private void OnItemBought(string id)
	{
		ItemBought?.Invoke(id);
	}

	public void OnCloseButtonClick()
	{
		CloseButtonClicked?.Invoke();
	}
}
