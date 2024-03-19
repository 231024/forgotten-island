using System;

namespace Wallet
{
	public class WalletModel
	{
		private int _gold;

		public WalletModel(int gold)
		{
			_gold = gold;
		}

		// todo add other resources
		public int[] Resources => new[] { Gold };

		private int Gold
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

		public event Action DataChanged;

		public bool TryWithdrawGold(int amount)
		{
			if (Gold < amount)
			{
				return false;
			}

			Gold -= amount;
			return true;
		}

		public void AddGold(int amount)
		{
			Gold += amount;
		}
	}
}
