namespace Core
{
	public abstract class AWindowPresenter : IWindowPresenter
	{
		private readonly IWindowView _windowView;

		protected AWindowPresenter(IWindowView view)
		{
			_windowView = view;
		}

		public virtual void Show()
		{
			_windowView.Show();
		}

		public virtual void Hide()
		{
			_windowView.Hide();
		}
	}
}