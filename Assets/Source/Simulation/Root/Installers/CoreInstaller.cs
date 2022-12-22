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
        /*GroupsContainer groups;
        CollectorsContainer collectors;
        [SerializeField] CoreStateProperty state = new CoreStateProperty();
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
            Container.BindInterfacesTo<ZenjectToEcsTransformer>().AsSingle().WithArguments(_installInfo).NonLazy();
        }
        
        void InstallContexts()
        {
            contexts = new Contexts();
            Container.BindInstance(contexts).AsSingle();
        }
        
        void InstallSystems()
        {
            Add<CreateSystem>(entites.Player);
            Add<HelloWorldSystem>();
        }
        
        void InstallEntities()
        {
            entites = new EntitiesContainer
            {
                Player = contexts.Game.CreateEntity()
            };
        }

        void InstallCoreSettings()
        {
            Container.BindInstance(settings.Businesses).AsSingle().IfNotBound();
        }
        
        private void Add<TSystem>(params object[] optionalArguments) where TSystem : ISystem
        {
            Container.InstallSystem<TSystem>(_installInfo, optionalArguments);
        }
    }
}
