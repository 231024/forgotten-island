using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

public class UnitPool
{
	private readonly ObjectPool<IProduct> _pool;
	private string _id;
	private Unit _prefab;
	private int _weight;
	private Sprite _sprite;

	public static event Action EventInstantiate;
	

		public UnitPool(string id, Unit prefab, Sprite sprite, int weight, int capacity = 10, int maxCapacity = 100)
	{
		_id = id;
		_prefab = prefab;
		_sprite = sprite;
		_weight = weight;
		_pool = new ObjectPool<IProduct>(Create, Get, Release, Destroy, true, capacity, maxCapacity);
	}

	private void Destroy(IProduct obj)
	{
		Object.Destroy(obj.GO);
	}

	public void Release(IProduct obj)
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
		var _warrior = Object.Instantiate(_prefab);
		_warrior.SetWeight(_weight);

		return _warrior;
	}

	public IProduct Get()
	{
		return _pool.Get();
	}

	public Sprite Avatar
	{
		get => _sprite;
		set
		{
			if(_sprite == value)
			{
				return;
			}
			_sprite = value;
		}
	}


}
