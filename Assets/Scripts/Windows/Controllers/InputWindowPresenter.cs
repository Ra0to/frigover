using Windows.Views;
using Core;

namespace Windows
{
	public class InputWindowPresenter: AWindowPresenter
	{
		private readonly InputWindowView _view;
		private readonly IWindowsController _windowsController;

		public InputWindowPresenter(InputWindowView view, IWindowsController windowsController) : base(view)
		{
			_view = view;
			_windowsController = windowsController;
		}

		public override void Show()
		{
			base.Show();
			Subscribe();
		}

		private void Subscribe()
		{
			_view.SubmitButton.onClick.RemoveAllListeners();
			_view.SubmitButton.onClick.AddListener(OnSubmitClick);
			_view.BackButton.onClick.AddListener(OnBackClick);
		}
		
		private void OnBackClick()
		{
			_windowsController.Window<ResultsWindowsPresenter>().Open();
		}

		private void OnSubmitClick()
		{
			var prev = Data.Promile;
			Data.Promile += (float.Parse(_view.Drink1.Volume.text ?? "0") / 100f * float.Parse(_view.Drink1.Grade.text ?? "0") * 0.789f) / (61f * 0.7f);
			D.Error($"{Data.Promile - prev}/{Data.Promile}");
			prev = Data.Promile;
			Data.Promile += (float.Parse(_view.Drink2.Volume.text ?? "0") / 100f * float.Parse(_view.Drink2.Grade.text ?? "0") * 0.789f) / (61f * 0.7f);
			D.Error($"{Data.Promile - prev}/{Data.Promile}");
			// Data.Promile += (float.Parse(_view.Drink3.Volume.text ?? "0") / 100f * float.Parse(_view.Drink3.Grade.text ?? "0") * 0.789f) / (61f * 0.7f);
			Data.Ready = true;
			_windowsController.Window<ResultsWindowsPresenter>().Open();
		}
	}

	public static class Data
	{
		public static float Promile = 0f;
		public static bool Ready = false;
	}
}