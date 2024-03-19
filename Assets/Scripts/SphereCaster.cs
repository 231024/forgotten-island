using DG.Tweening;
using UnityEngine;

public class SphereCaster : MonoBehaviour
{
	[SerializeField] private GameObject _camera;
	[SerializeField] private GameObject _target;
	[SerializeField] private LayerMask _mask;

	private void Update()
	{
		RaycastHit hit;
		if (Physics.Raycast(_camera.transform.position,
			    (_target.transform.position - _camera.transform.position).normalized, out hit, Mathf.Infinity,
			    _mask))
		{
			if (hit.collider.gameObject.CompareTag("Sight"))
			{
				_target.transform.DOScale(0, 1);
			}
			else
			{
				_target.transform.DOScale(2, 1);
			}
		}
	}
}