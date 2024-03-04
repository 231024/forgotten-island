using Command;
using UnityEngine;

namespace Radio
{
	public class Controller : MonoBehaviour
	{
		[SerializeField] private View _view;
		[SerializeField] private ImageView _imageView;
		[SerializeField] private float _hp;

		private Model _model;
		private Calculator _calculator;

		private void Awake()
		{
			_model = new Model(_hp);
			_model.Add(_view);
			_model.Add(_imageView);
			_model.Notify();

			_calculator = new Calculator();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_model.Hp--;
				_model.Notify();
			}
			
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				_calculator.ExecuteCommand(new AddCommand(7));
			}
			
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				_calculator.ExecuteCommand(new SubtractCommand(11));
			}
			
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				_calculator.Undo();
			}
			
			if (Input.GetKeyDown(KeyCode.C))
			{
				if (Input.GetKey(KeyCode.LeftCommand))
				{
					Clipboard.Instance.SetText("Special sentence for clipboard testing");
				}
			}
			
			if (Input.GetKeyDown(KeyCode.V))
			{
				if (Input.GetKey(KeyCode.LeftCommand))
				{
					var text = Clipboard.Instance.GetText();
					Debug.Log($"Output: {text}");
				}
			}
		}

		private void OnDestroy()
		{
			_model.Remove(_view);
			_model.Remove(_imageView);
		}
	}
}
