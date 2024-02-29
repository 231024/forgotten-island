using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
	[SerializeField] private Unit _player;

	public event Action<Vector3> GroundTouched ;

	private void OnMouseDown()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		GroundTouched?.Invoke(hit.point);
	}
}
