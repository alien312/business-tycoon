using NanoEcs;
using Source.Simulation.Settings;
using Zenject;

namespace Source.Simulation.Systems
{
    public class CreateSystem : SystemEcs, Iinitializable
    {
        [Inject] private Businesses businessSettings;
        
        private readonly Contexts _contexts;

        public CreateSystem(Contexts contexts, GameEntity player)
        {
            _contexts = contexts;
        }
        
        public void Initialize()
        {
            foreach (var business in businessSettings.BusinessesSettings)
            {
                var entity = _contexts.Game.CreateEntity();
                entity.AddSettings(business);
                entity.AddBusinessId(business.BusinessId);
                entity.AddIncomeProgress(0);
                entity.AddIncomeValue(business.BaseIncome);
                entity.AddLevel(business.IsUnlockedByDefault ? 1 : 0);
            }
            
        }
    }
}