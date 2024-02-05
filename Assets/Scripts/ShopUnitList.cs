using UnityEngine;

[CreateAssetMenu(menuName = "231024/ShopUnitList", fileName = "ShopUnitList")]
public class ShopUnitList : ScriptableObject
{
	[SerializeField] private ShopUnit[] _units;

	public ShopUnit[] Units => _units;
}
