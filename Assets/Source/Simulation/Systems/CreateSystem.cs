using NanoEcs;
using Source.Services;
using Source.Simulation.Settings;
using Zenject;

namespace Source.Simulation.Systems
{
    public class CreateSystem : SystemEcs, Iinitializable
    {
        [Inject] private Businesses businessSettings;
        [Inject] private BusinessService businessService;
        [Inject] private PlayerService playerService;
        
        private readonly Contexts _contexts;
        private GameEntity _player;

        public CreateSystem(Contexts contexts, GameEntity player)
        {
            _contexts = contexts;
            _player = player;
        }
        
        public void Initialize()
        {
            _player.AddBalance(0);
            playerService.RegisterPlayer(_player);
            
            foreach (var business in businessSettings.BusinessesSettings)
            {
                var entity = _contexts.Game.CreateEntity();
                entity.AddSettings(business);
                entity.AddBusinessId(business.BusinessId);
                entity.AddIncomeProgress(0);
                if (business.IsUnlockedByDefault)
                {
                    entity.AddLevel(1);
                    entity.IsActive = true;
                }
                else
                {
                    entity.AddLevel(0);
                }

                entity.AddModifiers(new NanoList<float> {0, 0});
                entity.AddIncomeValue(business.BaseIncome);
                entity.AddCost((entity.Level.Value + 1) * business.BaseCost);
                
                businessService.RegisterBusiness(business.BusinessId, entity);
            }
        }
    }
}