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
        }

        private void InstantiateProjectSettings()
        {
            coreSettings = Instantiate(coreSettings);
        }

        private void InstallProjectSettings()
        {
            Container.BindInstance(coreSettings).AsSingle();
        }
    }
}