using NanoEcs;

namespace Source.Simulation.Root.Installers.DataInstallers
{
    public static class EcsContainerInjectionExtension
    {
        public static void InstallSystem<TSystem>(this Zenject.DiContainer Container, InstallSettings installSettings, params object[] optionalArguments) where TSystem : ISystem
        {
            Container.Bind<TSystem>()
                .AsSingle()
                .WithConcreteId("system")
                .WithArguments(optionalArguments)
                .NonLazy();
        
            installSettings.Add<TSystem>(optionalArguments);
        }
    }
}