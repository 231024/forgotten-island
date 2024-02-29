using System.Collections.Generic;

namespace Radio
{
	public class Model : IObservable
	{
		private readonly List<IObserver> _observers = new();

		public Model(float initialHpValue)
		{
			Hp = initialHpValue;
		}

		public float Hp { get; set; }

		public void Notify()
		{
			foreach (var o in _observers)
			{
				o.HandleEvent(Hp);
			}
		}

		public void Add(IObserver o)
		{
			_observers.Add(o);
		}

		public void Remove(IObserver o)
		{
			_observers.Remove(o);
		}
	}
}
