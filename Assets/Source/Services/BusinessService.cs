using System;
using System.Collections.Generic;
using Source.Simulation.Settings;
using UniRx;
using Zenject;

namespace Source.Services
{
    public class BusinessService
    {
        #region Dependencies
        [Inject] private PlayerService playerService;
        [Inject] private Contexts contexts;
        #endregion

        #region State
        private readonly Dictionary<string, BusinessInfo> _businesses = new ();
        #endregion

        #region Callbacks
        public Action<string, string> ModifierApplied;
        public Action LevelUpdateApplied;
        #endregion

        #region API
        public void RegisterBusiness(string id, GameEntity business)
        {
            if (_businesses.ContainsKey(id))
            {
                return;
            }
            
            _businesses.Add(id, new BusinessInfo((BusinessSettings) business.Settings.Value, business));
        }
        public void RegisterModifier(string businessId, string modifierId)
        {
            if (TryGetBusinessInfo(businessId, out var info))
            {
                var modInfo = info.Settings.GetModifierInfo(modifierId);
                if (modInfo != null)
                {
                    playerService.ChangeBalance(-modInfo.Cost);
                    var mod = contexts.Game.CreateEntity();
                    mod.AddModifier(modInfo);
                    mod.AddTarget(info.Entity);
                    info.AddActiveModifier(modifierId);
                }
            }
        }

        public bool CanBuyLevelUpdate(string id)
        {
            if (! TryGetBusinessInfo(id, out var info)) return false;
            return playerService.PlayerBalance >= (info.Entity.Level.Value + 1) * info.Settings.BaseCost;
        }
        public bool CanBuyModifier(string id, string modifierId)
        {
            if (! TryGetBusinessInfo(id, out var info)) return false;
            var modInfo = info.Settings.GetModifierInfo(modifierId);
            if (modInfo == null) return false;
            return playerService.PlayerBalance >= modInfo.Cost && !info.IsModifierActive(modifierId);
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
                info.Entity.IncomeValue.Value = info.Settings.BaseIncome * info.Entity.Level.Value * info.Entity.IncreaseIncomeModifier.Value;
            }
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

        private readonly struct BusinessInfo
        {
            public readonly BusinessSettings Settings;
            public readonly GameEntity Entity;
            
            private readonly List<string> _activeModifiers;

            public BusinessInfo(BusinessSettings settings, GameEntity entity)
            {
                Settings = settings;
                Entity = entity;
                _activeModifiers = new List<string>();
                foreach (var mod in settings.Modifiers)
                {
                    mod.BusinessId = settings.BusinessId;
                }
            }

            public void AddActiveModifier(string id)
            {
                _activeModifiers.Add(id);
            }

            public bool IsModifierActive(string id)
            {
                return _activeModifiers.Contains(id);
            }
        }
    }
}