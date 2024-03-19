using UnityEngine;

public interface IProduct
{
	public GameObject GO { get; }
	public int Weight { get; }
	public void MoveTo(Vector3 targetPos);
}