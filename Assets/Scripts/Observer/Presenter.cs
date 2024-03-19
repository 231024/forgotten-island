using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Observer
{
	public class Presenter : IObservable<Model>, IDisposable
	{
		private readonly List<IObserver<Model>> _observers = new();
		private readonly View _view;
		private Model _model;

		public Presenter(View view)
		{
			_model = new Model
			{
				DogCount = 5,
				Gold = 100
			};

			_view = view;
			_view.CloseButtonClicked += OnViewCloseButtonClicked;
			_view.ItemBought += OnItemBought;
			_view.OnNext(_model);
		}

		public void Dispose()
		{
			_view.CloseButtonClicked -= OnViewCloseButtonClicked;
			_view.ItemBought -= OnItemBought;
		}

		public IDisposable Subscribe(IObserver<Model> observer)
		{
			if (!_observers.Contains(observer))
			{
				_observers.Add(observer);
			}

			return new UnSubscriber(_observers, observer);
		}

		private void OnViewCloseButtonClicked()
		{
			Object.Destroy(_view.gameObject);
		}

		private void OnItemBought(string id)
		{
			// _factory.GetProduct(id);

			_model.DogCount--;
			_model.Gold -= 20;
			Notify();
		}

		private void Notify()
		{
			foreach (var observer in _observers)
			{
				observer.OnNext(_model);
			}
		}

		private class UnSubscriber : IDisposable
		{
			private readonly List<IObserver<Model>> _allObservers;
			private readonly IObserver<Model> _observer;

			public UnSubscriber(List<IObserver<Model>> allObservers, IObserver<Model> observer)
			{
				_allObservers = allObservers;
				_observer = observer;
			}

			public void Dispose()
			{
				if (_observer != null && _allObservers.Contains(_observer))
				{
					_allObservers.Remove(_observer);
				}
			}
		}
	}
}