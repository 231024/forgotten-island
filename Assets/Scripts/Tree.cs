using UnityEngine;

public class Tree : MonoBehaviour
{
	[SerializeField] private int _pieces;

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
