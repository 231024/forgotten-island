using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Tweener : MonoBehaviour
{
	private async void Start()
	{
		await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
		await transform.DOMove(transform.position + Vector3.left * 5.0f, 2.0f);
		Debug.Log("1");
		await transform.DOMove(transform.position + Vector3.up * 5.0f, 2.0f);
		Debug.Log("2");
	}
}