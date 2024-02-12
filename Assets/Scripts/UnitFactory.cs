using UnityEngine;

public class UnitFactory : Factory
{
	[SerializeField] private Pooler _pool;

	public override IProduct GetProduct(string id)
	{
		return _pool.Get();
	}
}
