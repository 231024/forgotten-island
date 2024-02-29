using UnityEngine;
using UnityEngine.UI;

namespace Radio
{
	public class View : MonoBehaviour, IObserver
	{
		[SerializeField] private Slider _slider;

		public void HandleEvent(float value)
		{
			_slider.value = value;
		}
	}
}
