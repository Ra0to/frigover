using UnityEngine;

namespace Core
{
	public interface IWindowView
	{
		void Show();
		void Hide();
		void Attach(Transform parent);
	}
}