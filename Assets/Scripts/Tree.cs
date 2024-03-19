using System;
using UnityEngine;

public class Tree : MonoBehaviour
{
	[SerializeField] private int _pieces;
	[SerializeField] private int _wood;
	[SerializeField] private GameObject _chopped_tree;

	private void OnDestroy()
	{
		for (var i = 0; i < _wood; i++)
		{
			Instantiate(_chopped_tree, transform.position, transform.rotation);
		}
	}

	private void OnMouseDown()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		TreeTouched?.Invoke(hit.point);
	}

	public event Action<Vector3> TreeTouched;

	public void Hit()
	{
		_pieces--;
		CheckPieces();
	}

	private void CheckPieces()
	{
		if (_pieces <= 0)
		{
			Destroy(gameObject);
		}
	}
}