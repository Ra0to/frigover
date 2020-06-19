using Windows.Views;
using Core;
using DG.Tweening;
using UnityEngine;

namespace Windows
{
	public class StatisticWindowPresenter: AWindowPresenter
	{
		private readonly StatisticWindowView _view;
		private readonly IWindowsController _windowsController;

		public StatisticWindowPresenter(StatisticWindowView view, IWindowsController windowsController) : base(view)
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
			_view.BackButton.onClick.AddListener(OnBackClick);
		}
		private void OnBackClick()
		{
			_windowsController.Window<ResultsWindowsPresenter>().Open();
		}
	}
}