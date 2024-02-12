using System;
using UnityEngine;

[Serializable]
public struct ShopUnit
{
	[SerializeField] private string _id;
	[SerializeField] private DogUnit _item;
	[SerializeField] private int _price;

	public string ID => _id;
	public DogUnit Item => _item;
	public int Price => _price;
}
