using System;
using UnityEngine;

public class ChoppedTree : MonoBehaviour
{
	[SerializeField] private int _reward;

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<Unit>())
		{
			Collected?.Invoke(_reward);
			Destroy(gameObject);
		}
	}

	public static event Action<int> Collected;
}