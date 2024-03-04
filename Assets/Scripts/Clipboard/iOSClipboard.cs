#if IOS_BUILD && !UNITY_EDITOR
using System.Runtime.InteropServices;

public class iOSClipboard : IClipboard
{
	public void SetText(string str)
	{
		SetText_(str);
	}

	public string GetText()
	{
		return GetText_();
	}

	[DllImport("__Internal")]
	private static extern void SetText_(string str);

	[DllImport("__Internal")]
	private static extern string GetText_();
}
#endif
