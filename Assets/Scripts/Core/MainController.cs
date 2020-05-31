using Windows;

namespace Core
{
	public class MainController
	{
		private readonly IWindowsController _windowsController;

		public MainController(IWindowsController windowsController)
		{
			_windowsController = windowsController;
			Start();
		}

		private void Start()
		{
			_windowsController.Window<MainWindowPresenter>().Open();
		}
	}
}