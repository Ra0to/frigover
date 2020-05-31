using Windows.Views;
using Core;
using DG.Tweening;
using UnityEngine;

namespace Windows
{
	public class RightWindowPresenter: AWindowPresenter
	{
		private readonly RightWindowView _view;
		private readonly IWindowsController _windowsController;
		private bool _isClicked;

		public RightWindowPresenter(RightWindowView view, IWindowsController windowsController) : base(view)
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
			_view.ScaleButton.onClick.AddListener(OnScaleClick);
			_view.Left.onClick.AddListener(OnLeftClick);
			_view.Right.onClick.AddListener(OnRightClick);
		}

		private void OnScaleClick()
		{
			var scale = Vector3.one * (_isClicked ? 1f : 0.5f); 
			_isClicked = !_isClicked;
			_view.transform.DOScale(scale, 1f);
		}

		private void OnLeftClick()
		{
			_windowsController.Window<MainWindowPresenter>().Open();
		}

		private void OnRightClick()
		{
			_windowsController.Window<LeftWindowPresenter>().Open();
		}
	}
}