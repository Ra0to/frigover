using Zenject;

namespace Core
{
	public class WindowsController : IWindowsController
	{
		private readonly NavigationStack _stack;
		private readonly DiContainer _container;

		public WindowsController(NavigationStack stack, DiContainer container)
		{
			_stack = stack;
			_container = container;
		}

		public Opener<T> Window<T>() where T : IWindowPresenter
		{
			var opener = new Opener<T>();
			opener.Subscribe(Open<T>);
			return opener;
		}

		private void Open<T>() where T : IWindowPresenter
		{
			_stack.Push(Get<T>());
		}

		public void Back()
		{
			_stack.Pop();
		}

		private IWindowPresenter Get<T>() where T : IWindowPresenter
		{
			return _container.Resolve<T>();
		}
	}
}