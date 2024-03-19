namespace Command
{
	public class AddCommand : ICommand<double>
	{
		private readonly double _valueToAdd;

		public AddCommand(double valueToAdd)
		{
			_valueToAdd = valueToAdd;
		}

		public double Execute(double currentValue)
		{
			return currentValue += _valueToAdd;
		}

		public double Undo(double currentValue)
		{
			return currentValue -= _valueToAdd;
		}
	}
}