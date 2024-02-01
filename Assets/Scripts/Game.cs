using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private TurtleNames _turtles;

	private Coroutine _coroutine;
	private CancellationTokenSource _token;

	private List<Task> _tasks;

	private void Start()
	{
		_token = new CancellationTokenSource();
		_coroutine = StartCoroutine(Print());
	}

	private void OnDestroy()
	{
		StopCoroutine(_coroutine);
		_token.Cancel();
		_token.Dispose();
	}

	private IEnumerator Print()
	{
		while (true)
		{
			yield return new WaitForKey(KeyCode.Space);
			PrintFrame();
		}
	}

	private async void PrintFrame()
	{
		var turtles = await PrintFrameAsynchronously();
		foreach (var turtle in turtles)
		{
			Debug.Log(turtle);
		}
	}

	private async Task<IEnumerable<string>> PrintFrameAsynchronously()
	{
		await Task.Delay(3000);
		var task = new Task<IEnumerable<string>>(() => { return _turtles.Where(value => value.Length < 4); }, _token.Token);
		if (_token.IsCancellationRequested)
		{
			return null;
		}
		return await task;
	}
}
