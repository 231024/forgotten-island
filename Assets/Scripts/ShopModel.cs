using System;

public class ShopModel
{
	private int _unitCount;
	private int _gold;

	public ShopModel(int gold, int unitCount)
	{
		_gold = gold;
		_unitCount = unitCount;
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

	public int DogCount
	{
		get => _unitCount;
		set
		{
			if (_unitCount == value)
			{
				return;
			}

			_unitCount = value;
			DataChanged?.Invoke();
		}
	}

	public event Action DataChanged;
}
