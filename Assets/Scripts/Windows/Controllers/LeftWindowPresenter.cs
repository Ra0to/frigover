using Windows.Views;
using Core;
using DG.Tweening;
using UnityEngine;

namespace Windows
{
	public class LeftWindowPresenter: AWindowPresenter
	{
		private readonly LeftWindowView _view;
		private readonly IWindowsController _windowsController;
		private bool _isClicked;

		public LeftWindowPresenter(LeftWindowView view, IWindowsController windowsController) : base(view)
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
			var scale = Vector3.one * (!_isClicked ? 90f : 0f);
			scale.x = 0f;
			scale.y = 0f;
			// scale.z = 0f;
			_isClicked = !_isClicked;
			_view.transform.DORotate(scale, 1f);
		}

		private void OnLeftClick()
		{
			_windowsController.Window<RightWindowPresenter>().Open();
		}

		private void OnRightClick()
		{
			_windowsController.Window<MainWindowPresenter>().Open();
		}
	}
}