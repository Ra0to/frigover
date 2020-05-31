using UnityEngine;

namespace Core
{
	public abstract class AWindowView : MonoBehaviour, IWindowView
	{
		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void Attach(Transform parent)
		{
			gameObject.transform.SetParent(parent, false);
		}
	}
}