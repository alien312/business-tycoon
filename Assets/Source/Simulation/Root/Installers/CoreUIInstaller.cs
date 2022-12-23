using Source.Simulation.Root.Installers.DataInstallers;
using Source.Simulation.Settings;
using Source.UI;
using UnityEngine;
using Zenject;

namespace Source.Simulation.Root.Installers
{
    public class CoreUIInstaller : Installer<CoreUIInstaller>
    {
        private readonly UiSettings _uiSettings;
        private GameGroup _businesses;

        public CoreUIInstaller(UiSettings uiSettings, GameGroup businesses)
        {
            _uiSettings = uiSettings;
            _businesses = businesses;
        }
        
        public override void InstallBindings()
        {
            var holder = GameObject.FindObjectOfType<SafeArea>().transform;
            Container.Bind<MainWindow>().FromComponentInNewPrefab(_uiSettings.MainWindow).UnderTransform(holder).AsSingle().WithArguments(_businesses);
            Container.Bind<UiFactory>().AsCached();
            Container.BindInstance(_businesses).AsSingle();
        }
    }
}