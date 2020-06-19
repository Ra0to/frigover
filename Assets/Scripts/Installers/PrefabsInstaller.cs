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
    [SerializeField] private ResultsWindowsView _resultsWindowsView;
    [SerializeField] private StatisticWindowView _statisticWindowView;
    [SerializeField] private InputWindowView _inputWindowView;
    [SerializeField] private PropsWindowView _propsWindowView;
    
    [SerializeField] private CanvasProvider _canvasProvider;
    
    public override void InstallBindings()
    {
        Container.Bind<CanvasProvider>().FromComponentInNewPrefab(_canvasProvider).AsSingle();
        
        Container.BindWindow(_mainWindowView);
        Container.BindWindow(_leftWindowView);
        Container.BindWindow(_rightWindowView);
        Container.BindWindow(_resultsWindowsView);
        Container.BindWindow(_statisticWindowView);
        Container.BindWindow(_inputWindowView);
        Container.BindWindow(_propsWindowView);
    }
}