using System.Collections.Generic;
using UnityEngine;

namespace Wallet
{
	public class WalletView : MonoBehaviour
	{
		[SerializeField] private WalletItem _initialItem;
		[SerializeField] private RectTransform _parent;
		private readonly List<WalletItem> _items = new();

		private WalletModel _wallet;

		private void OnDestroy()
		{
			_wallet.DataChanged -= OnDataChanged;
		}

		public void Fill(WalletModel wallet)
		{
			if (_items.Count > 0)
			{
				return;
			}

			_wallet = wallet;

			foreach (var resource in _wallet.Resources)
			{
				var item = Instantiate(_initialItem, _parent);
				item.RefreshItem(resource);
				_items.Add(item);
			}

			_wallet.DataChanged += OnDataChanged;
		}

		private void OnDataChanged()
		{
			for (int i = 0, length = _wallet.Resources.Length; i < length; i++)
			{
				_items[i].RefreshItem(_wallet.Resources[i]);
			}
		}
	}
}
