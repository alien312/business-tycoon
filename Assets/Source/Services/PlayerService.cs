using System;
using UniRx;

namespace Source.Services
{
    public class PlayerService
    {
        private IObservable<float> _balanceStream;
        private GameEntity _player;

        #region API
        public void RegisterPlayer(GameEntity player)
        {
            _player = player;

            _balanceStream = player.ObserveEveryValueChanged(p => p.Balance.Value);
        }

        public ReadOnlyReactiveProperty<float> BalanceStream => _balanceStream.ToReadOnlyReactiveProperty();
        public float PlayerBalance => _player.Balance.Value;
        
        public void ChangeBalance(float value)
        {
            _player.Balance.Value += value;
        }
        #endregion
    }
}