using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooler : MonoBehaviour
{
	[SerializeField] private int _capacity;
	[SerializeField] private List<ShopUnit> _units;

	private ObjectPool<DogUnit> _pool;

	public List<ShopUnit> Units => _units;

	private void Start()
	{
		_pool = new ObjectPool<DogUnit>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy, true, _capacity,
			_capacity);
	}

	private void ActionOnDestroy(DogUnit obj)
	{
		Destroy(obj);
	}

	private void ActionOnRelease(DogUnit obj)
	{
		obj.gameObject.SetActive(false);
	}

	private void ActionOnGet(DogUnit obj)
	{
		obj.gameObject.transform.position = Vector3.zero;
		obj.gameObject.SetActive(true);
		obj.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
	}

	private DogUnit CreateFunc()
	{
		var unit = _units.Find(unit => unit.ID.Equals("dog"));
		return Instantiate(unit.Item);
	}

	public DogUnit Get()
	{
		return _pool.Get();
	}
}
