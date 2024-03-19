using UnityEngine;
using Zenject;

namespace Clipboard
{
	public class ClipboardPresenter : VContainer.Unity.IStartable
	{
		private readonly IClipboard _clipboard;

		[Inject]
		public ClipboardPresenter(IClipboard clipboard)
		{
			_clipboard = clipboard;
		}

		public void Start()
		{
			Debug.Log("Clipboard started");
		}

		public void SetText(string str)
		{
			_clipboard.SetText(str);
		}

		public string GetText()
		{
			return _clipboard.GetText();
		}
	}
}
