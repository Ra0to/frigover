using Windows;
using Windows.Views;
using Core;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PrefabsInstaller", menuName = "Installers/PrefabsInstaller")]
public class PrefabsInstaller : ScriptableObjectInstaller<PrefabsInstaller>
{
    [SerializeField] private MainWindowView _mainWindowView;
    [SerializeField] private LeftWindowView _leftWindowView;
    [SerializeField] private RightWindowView _rightWindowView;
    [SerializeField] private CanvasProvider _canvasProvider;
    
    public override void InstallBindings()
    {
        Container.Bind<CanvasProvider>().FromComponentInNewPrefab(_canvasProvider).AsSingle();
        
        Container.BindWindow(_mainWindowView);
        Container.BindWindow(_leftWindowView);
        Container.BindWindow(_rightWindowView);
    }
}