using System;
using System.Collections.Generic;


public class ShopModel
{
	private int _gold;
	private int _villageCapacity;
	private Dictionary<string, UnitPool> _warriorPools;


	public ShopModel(int gold, Dictionary<string, UnitPool> warriorPools, int villageCapacity)
	{
		_gold = gold;
		_warriorPools = warriorPools;
		_villageCapacity = villageCapacity;
	}


	public int Gold
	{
		get => _gold;
		set
		{
			if (_gold == value)
			{
				return;
			}

			_gold = value;
			DataChanged?.Invoke();
		}
	}

		public int VillageCapacity
	{
		get => _villageCapacity;
		set
		{
			if (_villageCapacity == value)
			{
				return;
			}

			_villageCapacity = value;
			DataChanged?.Invoke();
		}
	}


	public Dictionary<string, UnitPool> WarriorPools
	{
		get => _warriorPools;
		set
		{
			if (_warriorPools == value)
			{
				return;
			}
			_warriorPools = value;
			DataChanged?.Invoke();
		}
	}

	public event Action DataChanged;
}
