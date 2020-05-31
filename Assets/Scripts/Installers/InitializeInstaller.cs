using Windows;
using Windows.Views;
using Core;
using Zenject;

public class InitializeInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<WindowsController>().AsSingle();
        Container.BindInterfacesAndSelfTo<NavigationStack>().AsSingle();
        BindWindows();

        Container.Bind<MainController>().AsSingle().NonLazy();
    }

    private void BindWindows()
    {
        Container.Bind<MainWindowPresenter>().AsSingle();
        Container.Bind<LeftWindowPresenter>().AsSingle();
        Container.Bind<RightWindowPresenter>().AsSingle();
    }
}