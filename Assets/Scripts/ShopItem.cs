using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{



	[SerializeField] private Image _icon;
	[SerializeField] private TMP_Text _price;



	private Action<string> _buyClicked;

	private string _id;

	public void SetId(string id)
	{
		_id = id;
	}

	public void SetBuyButtonText(string text)
	{
		GetComponentInChildren<TextMeshProUGUI>().text = text;
	}


	public void SetCallback(Action<string> value)
	{
		_buyClicked = value;
	}

	public void SetPrice(string value)
	{
		_price.text = value;
	}
		public void SetImage(Sprite value)
	{
		_icon.sprite = value;
	}

	public void OnBuyButtonClick()
	{
		_buyClicked?.Invoke(_id);
	}
}
