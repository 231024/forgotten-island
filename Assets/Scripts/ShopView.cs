using System;
using TMPro;
using UnityEngine;

public class ShopView : MonoBehaviour
{
	[SerializeField] private ShopItem _initialItem;
	[SerializeField] private RectTransform _parent;
	[SerializeField] private TMP_Text _wallet;

	public void Refresh(ShopModel model)
	{
		_wallet.text = model.Gold.ToString();

		for (var i = 0; i < _parent.childCount; i++)
		{
			var element = _parent.GetChild(i);
			if (element.gameObject.activeSelf)
			{
				Destroy(element.gameObject);
			}
		}

		for (var i = 0; i != model.WarriorCount; i++)
		{
			var item = Instantiate(_initialItem, _parent);
			item.gameObject.SetActive(true);
			// item.SetId("dog");
			item.SetId(model.WarriorKinds[i]);
			// item.SetId(model.WarriorPools.Keys);
			// item.SetImage()
			item.SetCallback(OnItemBought);
		}

		// foreach(string key in model.WarriorPools)
		// 	{
		// 		_warriorKinds.Add(key);
		// 	}
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
