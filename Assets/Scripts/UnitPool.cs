using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

public class UnitPool
{
	private readonly ObjectPool<IProduct> _pool;
	private string _id;
	private Unit _prefab;

	public static event Action EventInstantiate;
	
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
		EventInstantiate?.Invoke();
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
