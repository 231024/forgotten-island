public interface IObservable
{
	public void Add(IObserver o);
	public void Remove(IObserver o);
	public void Notify();
}
