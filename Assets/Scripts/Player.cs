using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _distance;
	[SerializeField] private float _speed;

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	public void MoveTo(Vector3 targetPos)
	{
		StopAllCoroutines();
		StartCoroutine(Move(targetPos));
	}

	private IEnumerator Move(Vector3 targetPos)
	{
		while (Vector3.Distance(transform.position, targetPos) > _distance)
		{
			transform.position = Vector3.Lerp(transform.position, targetPos, _speed * Time.deltaTime);
			yield return null;
		}
	}
}
