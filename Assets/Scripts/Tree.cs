using System;
using UnityEngine;

public class Tree : MonoBehaviour
{
	[SerializeField] private int _pieces;
	[SerializeField] private int _wood;
	[SerializeField] private GameObject _chopped_tree;

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

	private void OnMouseDown()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		TreeTouched?.Invoke(hit.point);
	}

	private void OnDestroy()
	{
		for (int i = 0; i < _wood; i++)
		{
			Instantiate(_chopped_tree, transform.position, transform.rotation );
		}
		
	}
}
