using System;

namespace Core
{
	public class Opener<T> where T : IWindowPresenter
	{
		public delegate void Listener<TL>() where TL : IWindowPresenter;

		private Listener<T> _listener;
		public void Subscribe(Listener<T> listener)
		{
			_listener = listener;
		}

		public void Unsubscribe()
		{
			_listener = null;
		}

		public void Open()
		{
			_listener?.Invoke();
		}
	}
}