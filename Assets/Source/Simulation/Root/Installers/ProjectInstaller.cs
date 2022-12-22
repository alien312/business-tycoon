using Source.Simulation.Settings;
using UnityEngine;
using Zenject;

namespace Source.Simulation.Root.Installers
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        [SerializeField] private CoreSettings businessSettings;

        public override void InstallBindings()
        {
            InstantiateProjectSettings();
            InstallProjectSettings();
        }

        private void InstantiateProjectSettings()
        {
            businessSettings = Instantiate(businessSettings);
        }

        private void InstallProjectSettings()
        {
            Container.BindInstance(businessSettings).AsSingle();
        }
    }
}