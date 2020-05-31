using UnityEngine;
using Zenject;

namespace Core
{
	public static class WindowsContainerExtension
	{
		public static void BindWindow<T>(this DiContainer container, T prefab) where T : MonoBehaviour
		{
			prefab.gameObject.SetActive(false);
			container.Bind<T>().FromInstance(prefab).WhenInjectedInto<WindowPrefabsFactory<T>>();
			container.Bind<T>().FromFactory<WindowPrefabsFactory<T>>().AsSingle();
		}
	}
}