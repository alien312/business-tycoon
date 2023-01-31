using NanoEcs;
using Source.Data.Modifiers;
using Source.Services;
using Source.Simulation.Settings;
using Source.Simulation.Root;
using Zenject;

namespace Source.Simulation.Systems
{
    public class ModifiersHandleSystem : SystemEcs, IExecutable
    {
        [Inject] private BusinessService _businessService;
        private readonly GameCollector _addedModifiers;
        
        public ModifiersHandleSystem(GameCollector addedModifiers)
        {
            _addedModifiers = addedModifiers;
        }

        public void Execute()
        {
            foreach (var modifier in _addedModifiers)
            {
                var mod = (ModifierInfo) modifier.Modifier.Type;
                var business = modifier.Target.Value;
                switch (mod)
                {
                    case IncreaseIncomeModifierInfo incomeMod:
                        business.IncreaseIncomeModifier.Value += incomeMod.Value;
                        business.IncomeValue.Value = business.Settings<BusinessSettings>().BaseCost * business.Level.Value * business.IncreaseIncomeModifier.Value;
                        break;
                    case ReduceIncomeTimeModifierInfo reduceTimeMod:
                        business.ReduceIncomeTimeModifier.Value += reduceTimeMod.Value;
                        business.BaseIncomeTime.Value = business.Settings<BusinessSettings>().BaseIncomeTime / business.ReduceIncomeTimeModifier.Value;
                        break;
                }
                
                _businessService.ModifierApplied?.Invoke(mod.BusinessId, mod.Id);
            }
            
            _addedModifiers.Clear();
        }
    }
}