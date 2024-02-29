using UnityEngine;

public interface IProduct
{
	public void MoveTo(Vector3 targetPos);
	public GameObject GO { get; }
}
