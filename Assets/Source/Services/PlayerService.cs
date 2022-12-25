using System;
using UniRx;

namespace Source.Services
{
    public class PlayerService
    {
        public ReadOnlyReactiveProperty<float> BalanceStream => _balanceStream.ToReadOnlyReactiveProperty();
        public float PlayerBalance => _player.Balance.Value;
        
        private IObservable<float> _balanceStream;
        private GameEntity _player;
        
        public void RegisterPlayer(GameEntity player)
        {
            _player = player;

            _balanceStream = player.ObserveEveryValueChanged(p => p.Balance.Value);
        }

        public void ChangeBalance(float value)
        {
            _player.Balance.Value += value;
        }
    }
}