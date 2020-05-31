using UnityEngine;
using Zenject;

namespace Core
{
	public class WindowPrefabsFactory<T> : IFactory<T> where T : MonoBehaviour
	{
		private readonly CanvasProvider _provider;
		private readonly DiContainer _container;
		private readonly T _prefab;
		private readonly int _layer;

		public WindowPrefabsFactory(CanvasProvider provider, DiContainer container, T prefab)
		{
			_provider = provider;
			_container = container;
			_prefab = prefab;
			_layer = _provider.AttachPoint.gameObject.layer;
		}

		public T Create()
		{
			var gameObject = _container.InstantiatePrefab(_prefab, _provider.AttachPoint);
#if UNITY_EDITOR
			gameObject.name = gameObject.name.Replace("(Clone)", "");
#endif
			gameObject.layer = _layer;

			return gameObject.GetComponent<T>();
		}
	}
}