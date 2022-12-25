using NanoEcs;
using Source.Simulation.Settings;

namespace Source.Simulation.Systems
{
    public class IncomeSystem : SystemEcs, IExecutable
    {
        private GameEntity _player;
        private GameGroup _businesses;
        
        public IncomeSystem(GameGroup businesses, GameEntity player)
        {
            _businesses = businesses;
            _player = player;
        }
        
        public void Execute()
        {
            foreach (var business in _businesses)
            {
                var settings = (BusinessSettings) business.Settings.Value;
                
                if (business.IncomeProgress.Value >= settings.IncomeTime)
                {
                    _player.Balance.Value += business.IncomeValue.Value;
                    UnityEngine.Debug.Log($"business {settings.BusinessId} get income {business.IncomeValue.Value}");
                    business.IncomeProgress.Value = 0;
                }
            }
        }
    }
}