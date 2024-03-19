using UnityEngine;

namespace Wallet
{
	public class WalletPresenter : MonoBehaviour
	{
		private const int InitialGold = 100;

		[SerializeField] private WalletView _walletView;

		private WalletModel _model;

		public int Gold => InitialGold;

		public void Start()
		{
			_model = new WalletModel(InitialGold);
			_walletView.Fill(_model);

			ChoppedTree.Collected += OnChoppedTreeCollected;
		}

		private void OnDestroy()
		{
			ChoppedTree.Collected -= OnChoppedTreeCollected;
		}

		private void OnChoppedTreeCollected(int amount)
		{
			_model.AddGold(amount);
		}

		public bool TryWithdrawGold(int amount)
		{
			return _model.TryWithdrawGold(amount);
		}
	}
}
