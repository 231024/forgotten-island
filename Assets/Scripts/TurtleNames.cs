using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleNames : MonoBehaviour, IEnumerable<string>
{
	[SerializeField] private List<string> _names;

	public IEnumerator<string> GetEnumerator()
	{
		return new TurtleEnumerator(_names);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

public class TurtleEnumerator : IEnumerator<string>
{
	private readonly string[] _names;
	private IEnumerator<string> _enumeratorImplementation;
	private int _index = -1;

	public TurtleEnumerator(List<string> names)
	{
		_names = names.ToArray();
	}

	public string Current => _names[_index];

	public bool MoveNext()
	{
		_index++;
		return _index < _names.Length;
	}

	public void Reset()
	{
		_index = -1;
	}

	object IEnumerator.Current => ((IEnumerator)_enumeratorImplementation).Current;

	public void Dispose()
	{
	}
}
