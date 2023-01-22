using NanoEcs;
using Source.Data;
using Source.Handlers;
using Source.Services;
using Source.Simulation.Root.Installers.DataInstallers;
using Source.Simulation.Settings;
using Source.Simulation.Systems;
using Zenject;

namespace Source.Simulation.Root.Installers
{
    public class CoreInstaller : MonoInstaller
    {
        #region Dependencies
        [Inject] CoreSettings settings;
        [Inject] SessionData sessionData;
        #endregion
        
        #region InstallState
        Contexts contexts;
        EntitiesContainer entites;
        GameGroup businesses;
        GameGroup modifiers;
        GameGroup activeBusinesses;
        GameCollector modifierAdded;
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
            InstallServices();
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
            Container.Bind<ApplicationEventsHandler>()
                .FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.BindInterfacesTo<SaveSystem>().AsSingle()
                .WithArguments(new object[] 
                {
                    sessionData,
                    entites.Player,
                    businesses
                }).NonLazy();
            
            Add<CreateSystem>(entites.Player);
            Add<ProgressSystem>(businesses, contexts);
            Add<IncomeSystem>(businesses, entites.Player);
        }
        
        void InstallEntities()
        {
            entites = new EntitiesContainer
            {
                Player = contexts.Game.CreateEntity()
            };

            businesses = contexts.Game.GetGroup()
                .With.BusinessId;
            
            modifiers = contexts.Game.GetGroup()
                .With.Modifier;
        }

        void InstallCoreSettings()
        {
            Container.BindInstance(settings.Businesses).AsSingle().IfNotBound();
        }

        void InstallServices()
        {
            Container.Bind<BusinessService>().AsSingle();
            Container.Bind<PlayerService>().AsSingle();
        }
        
        void InstallUI()
        {
            Container.BindInstance(settings.UiSettings).AsSingle();
            Container.BindInstance(entites.Player).AsSingle().WhenInjectedInto<CoreUIInstaller>();
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
