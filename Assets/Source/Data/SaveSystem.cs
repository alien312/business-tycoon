using Source.Data.Modifiers;
using Source.Handlers;

namespace Source.Data
{
    public class SaveSystem : IPause, IQuit
    {
        private readonly SessionData _stateData;
        private readonly GameEntity _player;
        private readonly GameGroup _businesses;
        private readonly GameGroup _modifiers;

        private readonly SessionStateData _currentSessionStateData;

        public SaveSystem(SessionData stateData, GameEntity player, GameGroup businesses, GameGroup modifiers)
        {
            _stateData = stateData;
            _player = player;
            _businesses = businesses;
            _modifiers = modifiers;

            _currentSessionStateData = new SessionStateData();
        }
        
        public void Pause(bool pauseState)
        {
            if (pauseState)
            {
                SaveData();
            }
        }

        public void Quit()
        {
            SaveData();
        }

        private void SaveData()
        {
            _currentSessionStateData.PlayerBalance = _player.Balance.Value;

            _currentSessionStateData.Businesses.Clear();
            foreach (var business in _businesses)
            {
                var b = new Business
                {
                    Level = business.Level.Value,
                    BusinessId = business.BusinessId.Value,
                    IncomeProgress = business.IncomeProgress.Value,
                };
                _currentSessionStateData.Businesses.Add(b);
            }

            _currentSessionStateData.Modifiers.Clear();
            foreach (var modifier in _modifiers)
            {
                var mod = new Modifier
                {
                    BusinessId = modifier.Target.Value.BusinessId.Value,
                    ModifierId = ((ModifierInfo)modifier.Modifier.Type).Id
                };
                _currentSessionStateData.Modifiers.Add(mod);
            }

            _stateData.StateData = _currentSessionStateData;
        }
    }
}