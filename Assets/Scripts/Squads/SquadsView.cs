using System;
using System.Collections.Generic;
using UnityEngine;

namespace Squads
{
	public class SquadsView : MonoBehaviour
	{
		[SerializeField] private SquadsViewItem _itemButton;
		[SerializeField] private Transform _parent;

		public event Action<string> IdsInstance;

		public void ReInstantiate(IEnumerable<string> ids)
		{
			for (var i = 0; i < _parent.childCount; ++i)
			{
				Destroy(_parent.GetChild(i).gameObject);
			}

			foreach (var id in ids)
			{
				Instantiate(_itemButton, _parent).Init(id, CallBack);
			}
		}

		private void CallBack(string id)
		{
			IdsInstance?.Invoke(id);
		}
	}
}
