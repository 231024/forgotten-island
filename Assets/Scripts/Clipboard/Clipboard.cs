public class Clipboard
{
	private static IClipboard _board;

	public static IClipboard Instance
	{
		get
		{
			if (_board == null)
			{
#if ANDROID_BUILD && !UNITY_EDITOR
                _board = new AndroidClipboard();
#elif IOS_BUILD && !UNITY_EDITOR
                _board = new iOSClipboard();
#else
				_board = new UnityClipboard();
#endif
			}

			return _board;
		}
	}

	public void SetText(string str)
	{
		_board.SetText(str);
	}

	public string GetText()
	{
		return _board.GetText();
	}
}
