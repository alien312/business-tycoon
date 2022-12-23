using NanoEcs;
using Source.Simulation.Root.Installers.DataInstallers;
using Source.Simulation.Settings;
using Source.Simulation.Systems;
using Zenject;

namespace Source.Simulation.Root.Installers
{
    public class CoreInstaller : MonoInstaller
    {
        #region Dependencies
        [Inject] private CoreSettings settings;
        #endregion
        
        #region InstallState
        Contexts contexts;
        EntitiesContainer entites;
        GameGroup businesses;
        /*CollectorsContainer collectors;
        CoreSignals signals = new CoreSignals();*/
        #endregion
    
        private readonly InstallSettings _installInfo = new InstallSettings();
        
        void Awake()
        {
            _installInfo.Container = () => Container;
        }
        
        public override void InstallBindings()
        {
            InstallContexts();
            InstallCoreSettings();
            InstallEntities();
            InstallSystems();
            InstallUI();
            InstallZenjectToEcsTransporting();
        }
        
        void InstallContexts()
        {
            contexts = new Contexts();
            Container.BindInstance(contexts).AsSingle();
        }
        
        void InstallSystems()
        {
            Add<CreateSystem>(entites.Player);
        }
        
        void InstallEntities()
        {
            entites = new EntitiesContainer
            {
                Player = contexts.Game.CreateEntity()
            };

            businesses = contexts.Game.GetGroup()
                .With.BusinessId;
        }

        void InstallCoreSettings()
        {
            Container.BindInstance(settings.Businesses).AsSingle().IfNotBound();
        }
        
        void InstallUI()
        {
            Container.BindInstance(settings.UiSettings).AsSingle();
            Container.BindInstance(entites).AsSingle().WhenInjectedInto<CoreUIInstaller>();
            Container.BindInstance(businesses).AsSingle().WhenInjectedInto<CoreUIInstaller>();
            Container.Bind(typeof(MainWindow))
                .FromSubContainerResolve()
                .ByInstaller<CoreUIInstaller>()
                .WithKernel()
                .AsSingle();
        }
        
        void InstallZenjectToEcsTransporting()
        {
            Container.BindInterfacesTo<ZenjectToEcsTransporting>().AsSingle().WithArguments(_installInfo).NonLazy();
        }

        private void Add<TSystem>(params object[] optionalArguments) where TSystem : ISystem
        {
            Container.InstallSystem<TSystem>(_installInfo, optionalArguments);
        }
    }
}
