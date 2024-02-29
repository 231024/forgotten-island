using UnityEngine;

public class FactorySingleton
{
	private static FactorySingleton _instance;
	private int _count;

	public static FactorySingleton Instance()
	{
		if (_instance != null)
		{
			return _instance;
		}

		_instance = new FactorySingleton();
		return _instance;
	}

	public void PrintSmthn()
	{
		_count++;
		Debug.Log($"{_count} We were created singleton without any reason");
	}
}
