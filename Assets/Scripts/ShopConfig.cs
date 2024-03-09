using System;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
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
	[SerializeField] private int _weight;
	[SerializeField] private Unit _prefab;
	[SerializeField] private Sprite _sprite;


	public string ID => _id;
	public int Weight => _weight;
	public Unit Prefab => _prefab;
	public Sprite Sprite => _sprite;
}
