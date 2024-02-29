using UnityEngine;
using UnityEngine.UI;

public class ImageView : MonoBehaviour, IObserver
{
	[SerializeField] private Image _image;

	public void HandleEvent(float value)
	{
		_image.fillAmount = value / 100.0f;
	}
}
