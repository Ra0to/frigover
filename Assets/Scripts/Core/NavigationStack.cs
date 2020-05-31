using System.Collections.Generic;

namespace Core
{
	public class NavigationStack
	{
		public IWindowPresenter Top => _stack.Peek();
		private Stack<IWindowPresenter> _stack = new Stack<IWindowPresenter>();
		
		public void Push(IWindowPresenter presenter)
		{
			if (_stack.Count >= 1)
				Top.Hide();
			_stack.Push(presenter);
			Top.Show();
		}

		public void Pop()
		{
			if (_stack.Count == 1)
			{
				D.Warning("Can not close last window");
				return;
			}
			
			Top.Hide();
			_stack.Pop();
			Top.Show();
		}
	}
}