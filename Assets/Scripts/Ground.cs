using UnityEngine;

public class Ground : MonoBehaviour
{
	[SerializeField] private Player _player;

	private void OnMouseDown()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		_player.MoveTo(hit.point);
	}
}
