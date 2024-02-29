using System.Collections.Generic;
using UnityEngine;

namespace Command
{
	public class Calculator
	{
		private Stack<ICommand<double>> _commandHistory = new();

		private double _currentValue;
		private double CurrentValue
		{
			get => _currentValue;
			set
			{
				_currentValue = value;
				Debug.Log($"CALCULATOR: {_currentValue}");
			}
		}

		public void ExecuteCommand(ICommand<double> command)
		{
			CurrentValue = command.Execute(CurrentValue);
			_commandHistory.Push(command);
		}

		public void Undo()
		{
			var command = _commandHistory.Pop();
			CurrentValue = command.Undo(CurrentValue);
		}
	}
}
