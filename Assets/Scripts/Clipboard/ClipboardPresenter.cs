using System;
using UnityEngine;
using VContainer.Unity;
using Zenject;
using ITickable = VContainer.Unity.ITickable;

namespace Clipboard
{
	public class ClipboardPresenter : IStartable, ITickable, IDisposable
	{
		private readonly IClipboard _clipboard;

		[Inject]
		public ClipboardPresenter(IClipboard clipboard)
		{
			_clipboard = clipboard;
		}

		public void Dispose()
		{
		}

		public void Start()
		{
		}

		public void Tick()
		{
			Debug.Log("Clipboard");
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
