using System.Collections;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private TurtleNames _turtles;

	private Coroutine _coroutine;

	private void Start()
	{
		_coroutine = StartCoroutine(Print());
	}

	private void OnDestroy()
	{
		StopCoroutine(_coroutine);
	}

	private IEnumerator Print()
	{
		while (true)
		{
			yield return new WaitForKey(KeyCode.Space);
			PrintFrame();
		}
	}

	private void PrintFrame()
	{
		foreach (var turtle in _turtles.Where(value => value.Length < 4))
		{
			Debug.Log(turtle);
		}
	}
}
