using System;
using UnityEngine;

[Serializable]
public struct ShopUnit
{
	[SerializeField] private int _price;

	public int Price => _price;
}
