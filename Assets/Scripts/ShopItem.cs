using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
	[SerializeField] private Image _icon;
	[SerializeField] private TMP_Text _price;

	public Action _buyClicked;
	
	public void SetCallback(Action value)
	{
		_buyClicked = value;
	}

	public void SetPrice(string value)
	{
		_price.text = value;
	}

	public void OnBuyButtonClick()
	{
		_buyClicked?.Invoke();
	}
}
