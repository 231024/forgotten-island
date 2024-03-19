using System;
using TMPro;
using UnityEngine;

namespace Observer
{
	public class View : MonoBehaviour, IObserver<Model>
	{
		[SerializeField] private ShopItem _initialItem;
		[SerializeField] private RectTransform _parent;
		[SerializeField] private TMP_Text _wallet;

		private void Awake()
		{
			var presenter = new Presenter(this);
			presenter.Subscribe(this);
		}

		public virtual void OnCompleted()
		{
		}

		public virtual void OnError(Exception e)
		{
			Debug.LogError(e.Message);
		}

		public virtual void OnNext(Model model)
		{
			Debug.Log(model.DogCount);

			_wallet.text = model.Gold.ToString();

			for (var i = 0; i < _parent.childCount; i++)
			{
				var element = _parent.GetChild(i);
				if (element.gameObject.activeSelf)
				{
					Destroy(element.gameObject);
				}
			}

			for (var i = 0; i != model.DogCount; i++)
			{
				var item = Instantiate(_initialItem, _parent);
				item.gameObject.SetActive(true);
				item.SetId("dog");
				// item.SetPrice(unit.Price.ToString());
				item.SetCallback(OnItemBought);
			}
		}

		public event Action CloseButtonClicked;
		public event Action<string> ItemBought;

		private void OnItemBought(string id)
		{
			ItemBought?.Invoke(id);
		}

		public void OnCloseButtonClick()
		{
			CloseButtonClicked?.Invoke();
		}
	}
}