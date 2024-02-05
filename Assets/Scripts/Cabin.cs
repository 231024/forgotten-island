using System;
using UnityEngine;

public class Cabin : MonoBehaviour
{
	private void OnMouseDown()
	{
		CabinTouched?.Invoke();
	}

	public event Action CabinTouched;
}
