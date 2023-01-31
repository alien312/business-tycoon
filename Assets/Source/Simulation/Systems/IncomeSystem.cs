using NanoEcs;
using Source.Simulation.Settings;
using Source.Simulation.Root;

namespace Source.Simulation.Systems
{
    public class IncomeSystem : SystemEcs, IExecutable
    {
        private readonly GameEntity _player;
        private readonly GameGroup _businesses;
        
        public IncomeSystem(GameGroup businesses, GameEntity player)
        {
            _businesses = businesses;
            _player = player;
        }
        
        public void Execute()
        {
            foreach (var business in _businesses)
            {
                
                if (business.IncomeProgress.Value >= business.BaseIncomeTime.Value)
                {
                    _player.Balance.Value += business.IncomeValue.Value;
                    UnityEngine.Debug.Log($"business {business.BusinessId} get income {business.IncomeValue.Value}");
                    business.IncomeProgress.Value = 0;
                }
            }
        }
    }
}