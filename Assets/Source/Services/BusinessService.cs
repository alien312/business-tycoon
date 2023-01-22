using System;
using System.Collections.Generic;
using System.Linq;
using Source.Simulation.Settings;
using UniRx;
using Zenject;

namespace Source.Services
{
    public class BusinessService
    {
        #region Dependencies
        [Inject] private PlayerService playerService;
        #endregion

        #region State
        private readonly Dictionary<string, BusinessInfo> _businesses = new ();
        #endregion

        #region API
        public void RegisterBusiness(string id, GameEntity business)
        {
            if (_businesses.ContainsKey(id))
            {
                return;;
            }
            
            _businesses.Add(id, new BusinessInfo((BusinessSettings) business.Settings.Value, business));
        }

        public bool CanBuyLevelUpdate(string id)
        {
            if (! TryGetBusinessInfo(id, out var info)) return false;
            return playerService.PlayerBalance >= (info.Entity.Level.Value + 1) * info.Settings.BaseCost;
        }
        public bool CanBuyModifier(string id, int index)
        {
            if (! TryGetBusinessInfo(id, out var info)) return false;
            return (playerService.PlayerBalance >= info.Settings.GetModifierCostOld(index)) && !(info.IsModifierBought(index));
        }
        
        public void UpdateBusinessLevel(string id)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                playerService.ChangeBalance(-info.Entity.Cost.Value);
                info.Entity.Level.Value++;
                if (info.Entity.Level.Value == 1)
                {
                    info.Entity.IsActive = true;
                }
                info.Entity.Cost.Value = info.Settings.BaseCost * (info.Entity.Level.Value + 1);
                info.Entity.IncomeValue.Value = info.Settings.BaseIncome * info.Entity.Level.Value * (1 + info.Entity.Modifiers.Value.Sum());
            }
        }
        public void ApplyModifier(string id, int index)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                if (index < info.Settings.ModifiersCount)
                {
                    playerService.ChangeBalance(-info.Settings.GetModifierCostOld(index));
                    var m = info.Entity.Modifiers.Value;
                    m[index] = info.Settings.GetModifierMultiplayer(index);
                    info.Entity.Modifiers.Value = m;
                    info.Entity.IncomeValue.Value = info.Settings.BaseIncome * info.Entity.Level.Value * (1 + info.Entity.Modifiers.Value.Sum());
                }
            }
        }
        
        public int GetBusinessLevel(string id)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                return info.Entity.Level.Value;
            }

            return 0;
        }
        public float GetBusinessUpdateCost(string id)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                return info.Entity.Cost.Value;
            }

            return 0;
        }
        public float GetBusinessIncome(string id)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                return info.Entity.IncomeValue.Value;
            }

            return 0;
        }
        
        public IObservable<float> GetBusinessIncomeProgressPercentageStream(string id)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                return info.Entity.ObserveEveryValueChanged(b=> b.IncomeProgress.Value / info.Settings.IncomeTime);
            }

            return null;
        } 

        public int GetModifiersCount(string id)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                return info.Settings.ModifiersCount;
            }

            return 0;
        }
        public float GetModifierCost(string id, int index)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                return info.Settings.GetModifierCostOld(index);
            }
            
            return 0;
        }
        public float GetModifierMultiplayer(string id, int index)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                return info.Settings.GetModifierMultiplayer(index);
            }
            
            return 0;
        }
        public bool GetModifierBoughtState(string id, int index)
        {
            if (TryGetBusinessInfo(id, out var info))
            {
                return info.Entity.Modifiers.Value[index] != 0;
            }
            
            return false;
        }
        #endregion
        
        private bool TryGetBusinessInfo(string id, out BusinessInfo info)
        {
            if (!_businesses.ContainsKey(id))
            {
                UnityEngine.Debug.LogError($"Business with ID {id} does not exist");
                info = new BusinessInfo();
                return false;
            }

            info = _businesses[id];
            return true;
        }
        
        struct BusinessInfo
        {
            public readonly BusinessSettings Settings;
            public GameEntity Entity;

            public BusinessInfo(BusinessSettings settings, GameEntity entity)
            {
                Settings = settings;
                Entity = entity;
            }

            public bool IsModifierBought(int index)
            {
                if (index > Entity.Modifiers.Value.Count) return false;
                return Entity.Modifiers.Value[index] != 0;
            }
        }
    }
}