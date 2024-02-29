using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "1024/Shop Config", fileName = "ShopConfig")]
public class ShopConfig : ScriptableObject
{
	[SerializeField] private List<ShopEntry> _entries;

	public List<ShopEntry> Entries => _entries;
}

[Serializable]
public class ShopEntry
{
	[SerializeField] private string _id;
	[SerializeField] private Unit _prefab;

	public string ID => _id;
	public Unit Prefab => _prefab;
}
