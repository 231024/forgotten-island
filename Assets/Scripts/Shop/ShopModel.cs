using System;
using System.Collections.Generic;

namespace Shop
{
	public class ShopModel
	{
		private int _villageCapacity;
		private Dictionary<string, UnitPool> _warriorPools;

		public ShopModel(Dictionary<string, UnitPool> warriorPools, int villageCapacity)
		{
			_warriorPools = warriorPools;
			_villageCapacity = villageCapacity;
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
}
