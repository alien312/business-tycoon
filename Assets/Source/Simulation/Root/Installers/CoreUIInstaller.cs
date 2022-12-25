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
        private GameEntity _player;

        public CoreUIInstaller(UiSettings uiSettings, GameGroup businesses, GameEntity player)
        {
            _uiSettings = uiSettings;
            _businesses = businesses;
            _player = player;
        }
        
        public override void InstallBindings()
        {
            var holder = GameObject.FindObjectOfType<SafeArea>().transform;
            Container.Bind<MainWindow>().FromComponentInNewPrefab(_uiSettings.MainWindow).UnderTransform(holder).AsSingle().WithArguments(_businesses, _player);
            Container.Bind<UiFactory>().AsCached().WithArguments(_player);
            Container.BindInstance(_businesses).AsSingle();
        }
    }
}