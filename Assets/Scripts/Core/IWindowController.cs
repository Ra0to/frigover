namespace Core
{
	public interface IWindowsController
	{
		Opener<T> Window<T>() where T : IWindowPresenter;
		void Back();
	}
}