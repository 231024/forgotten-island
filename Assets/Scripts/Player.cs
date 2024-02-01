using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _distance;
	[SerializeField] private float _speed;

	private readonly CancellationTokenSource _tokenSource = new();

	private void OnDisable()
	{
		StopAllCoroutines();
		_tokenSource.Cancel();
	}

	private void OnDestroy()
	{
		_tokenSource.Dispose();
	}

	public void MoveTo(Vector3 targetPos)
	{
		// StopAllCoroutines();
		// StartCoroutine(Move(targetPos));
		MoveAsync(targetPos);
	}

	private IEnumerator Move(Vector3 targetPos)
	{
		while (Vector3.Distance(transform.position, targetPos) > _distance)
		{
			transform.position = Vector3.Lerp(transform.position, targetPos, _speed * Time.deltaTime);
			yield return null;
		}
	}

	private async void MoveAsync(Vector3 targetPos)
	{
		while (Vector3.Distance(transform.position, targetPos) > _distance)
		{
			transform.position = Vector3.Lerp(transform.position, targetPos, _speed * Time.deltaTime);
			await Task.Yield();
		}
	}
}
