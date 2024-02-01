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
