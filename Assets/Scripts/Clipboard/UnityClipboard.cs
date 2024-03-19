using UnityEngine;

public class UnityClipboard : IClipboard
{
	public void SetText(string str)
	{
		GUIUtility.systemCopyBuffer = str;
	}

	public string GetText()
	{
		return GUIUtility.systemCopyBuffer;
	}
}