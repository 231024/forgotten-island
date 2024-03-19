using System.Collections.Generic;
using Shop;
using UnityEngine;

public class UnitFactory : Factory
{
	[SerializeField] private ShopConfig _config;

	public Dictionary<string, UnitPool> Pools { get; } = new();

	private void Awake()
	{
		foreach (var entry in _config.Entries)
		{
			Pools[entry.ID] = new UnitPool(entry.ID, entry.Prefab, entry.Sprite, entry.Weight);
		}
	}

	public override IProduct GetProduct(string id)
	{
		return Pools[id].Get();
	}

	public bool CheckSpaceForId(int capacity, string id)
	{
		return _config.Entries.Find(entry => entry.ID.Equals(id)).Weight <= capacity;
	}
}
