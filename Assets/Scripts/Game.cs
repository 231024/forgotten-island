using Cysharp.Threading.Tasks;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private TurtleNames _turtles;

	private void Start()
	{
		UniPrint();
	}

	private async void UniPrint()
	{
		await UniTask.WaitUntil(() => Input.anyKeyDown, PlayerLoopTiming.Update, destroyCancellationToken);
		await PrintFrameAsynchronously();
	}

	private async UniTask PrintFrameAsynchronously()
	{
		await UniTask.Delay(3000, false, PlayerLoopTiming.Update, destroyCancellationToken);
		foreach (var turtle in _turtles)
		{
			Debug.Log(turtle);
		}
		UniPrint();
	}
}
