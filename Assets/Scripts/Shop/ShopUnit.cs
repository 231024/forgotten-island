using System;
using UnityEngine;

[Serializable]
public struct ShopUnit
{
	[SerializeField] private string _id;
	[SerializeField] private Unit _item;
	[SerializeField] private int _price;

	public string ID => _id;
	public Unit Item => _item;
	public int Price => _price;
}