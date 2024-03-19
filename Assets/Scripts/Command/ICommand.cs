namespace Command
{
	public interface ICommand<T>
	{
		T Execute(T value);
		T Undo(T value);
	}
}