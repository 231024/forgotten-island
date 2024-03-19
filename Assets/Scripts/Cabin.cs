using System;
using UnityEngine;

public class Cabin : MonoBehaviour
{
	private void OnMouseDown()
	{
		Touched?.Invoke();
	}

	public event Action Touched;
}