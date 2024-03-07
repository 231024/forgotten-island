using System;
using System.Collections.Generic;


public class ShopModel
{
	private int _kindCount;
	private int _gold;
	private List<string> _warriorKinds;
	private Dictionary<string, UnitPool> _warriorPools;

	// public ShopModel(int gold, int unitCount)
	// {
	// 	_gold = gold;
	// 	_unitCount = unitCount;
	// }

	public ShopModel(int gold, int unitCount, List<string> warriorKinds)
	{
		_gold = gold;
		_kindCount = unitCount;
		_warriorKinds = warriorKinds; 
	}

	// public ShopModel(int gold, int unitCount, Dictionary<string, UnitPool> warriorPools)
	// {
	// 	_gold = gold;
	// 	_kindCount = unitCount;
	// 	_warriorPools = warriorPools;
	// }


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

	public int WarriorCount
	{
		get => _kindCount;
		set
		{
			if (_kindCount == value)
			{
				return;
			}

			_kindCount = value;
			DataChanged?.Invoke();
		}
	}

	public List<string> WarriorKinds
	{
		get => _warriorKinds;
		set
		{
			if (_warriorKinds == value)
			{
				return;
			}
			_warriorKinds = value;
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
