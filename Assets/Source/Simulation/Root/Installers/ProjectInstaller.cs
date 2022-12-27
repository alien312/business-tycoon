using Source.Data;
using Source.Simulation.Settings;
using UnityEngine;
using Zenject;

namespace Source.Simulation.Root.Installers
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        [SerializeField] private CoreSettings coreSettings;

        public override void InstallBindings()
        {
            InstantiateProjectSettings();
            InstallProjectSettings();
            InstallData();
            Container.BindInterfacesTo<SaveLoadHandler>().AsSingle().NonLazy();
        }

        private void InstantiateProjectSettings()
        {
            coreSettings = Instantiate(coreSettings);
        }

        private void InstallProjectSettings()
        {
            Container.BindInstance(coreSettings).AsSingle();
        }

        private void InstallData()
        {
            var data = new SessionData();
            Container.Bind<SessionData>().AsSingle();
        }
    }
}