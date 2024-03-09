using System;

public class WalletModel
{
	public event Action DataChanged;

	private int _gold;

	public WalletModel(int gold)
	{
		_gold = gold;
	}

	public int Gold
	{
		get => _gold;
		private set
		{
			if (_gold == value)
			{
				return;
			}

			_gold = value;
			DataChanged?.Invoke();
		}
	}

	public bool WithdrawGold(int amount)
	{
		if (Gold < amount)
			return false;

		Gold -= amount;
		return true;
	}
}