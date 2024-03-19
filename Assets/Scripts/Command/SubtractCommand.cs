namespace Command
{
	public class SubtractCommand : ICommand<double>
	{
		private readonly double _valueToSubtract;

		public SubtractCommand(double valueToSubtract)
		{
#if IOS_BUILD
			_valueToSubtract = valueToSubtract;
#elif ANDROID_BUILD
			_valueToSubtract = valueToSubtract;
#else
			_valueToSubtract = valueToSubtract;
#endif
		}

		public double Execute(double currentValue)
		{
			return currentValue -= _valueToSubtract;
		}

		public double Undo(double currentValue)
		{
			return currentValue += _valueToSubtract;
		}
	}
}