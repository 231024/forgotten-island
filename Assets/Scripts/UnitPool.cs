using UnityEngine;
using UnityEngine.Pool;

public class UnitPool
{
	private readonly ObjectPool<IProduct> _pool;
	private string _id;
	private Unit _prefab;

	public UnitPool(string id, Unit prefab, int capacity = 10, int maxCapacity = 100)
	{
		_id = id;
		_prefab = prefab;
		_pool = new ObjectPool<IProduct>(Create, Get, Release, Destroy, true, capacity, maxCapacity);
	}

	private void Destroy(IProduct obj)
	{
		Object.Destroy(obj.GO);
	}

	private void Release(IProduct obj)
	{
		obj.GO.SetActive(false);
	}

	private void Get(IProduct obj)
	{
		obj.GO.transform.position = Vector3.zero;
		obj.GO.SetActive(true);
		obj.GO.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
	}

	private IProduct Create()
	{
		return Object.Instantiate(_prefab);
	}

	public IProduct Get()
	{
		return _pool.Get();
	}
}
