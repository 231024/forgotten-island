using UnityEngine;

public class WalletPresenter : MonoBehaviour
{
	[SerializeField] private WalletView _walletView;
	private WalletModel _model;

	private const int InitialGold = 100;

	public void Start()
	{
		_model = new WalletModel(InitialGold);
		_walletView.Fill(_model);
	}

	public bool WithdrawGold(int amount) => _model.WithdrawGold(amount);
}