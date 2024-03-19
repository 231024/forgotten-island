using System;
using UnityEngine;

namespace Squads
{
	public class SquadsViewItem : MonoBehaviour
	{
		private Action<string> _callBackItem;
		private string _id;

		public void OnClick()
		{
			_callBackItem.Invoke(_id);
		}

		public void Init(string id, Action<string> callBack)
		{
			_id = id;
			_callBackItem = callBack;
		}
	}
}
