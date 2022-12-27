using System.Linq;
using Source.Handlers;

namespace Source.Data
{
    public class SaveSystem : IPause, IQuit
    {
        private SessionData _stateData;
        private GameEntity _player;
        private GameGroup _businesses;

        private SessionStateData _currentSessionStateData;

        public SaveSystem(SessionData stateData, GameEntity player, GameGroup businesses)
        {
            _stateData = stateData;
            _player = player;
            _businesses = businesses;

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
                    BoughtModifiers = business.Modifiers.Value.Select(m=>m != 0).ToList()
                };
                _currentSessionStateData.Businesses.Add(b);
            }

            _stateData.StateData = _currentSessionStateData;
        }
    }
}