using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
	private void OnMouseDown()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);

		// _player.MoveTo(hit.point);
		GroundTouched?.Invoke(hit.point);
	}

	public event Action<Vector3> GroundTouched;
}
