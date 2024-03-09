using TMPro;
using UnityEngine;

public class WalletItem : MonoBehaviour
{
	[SerializeField] private TMP_Text _value;

	public void RefreshItem(int value) => _value.SetText(value.ToString());
}