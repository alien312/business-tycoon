using System.Collections.Generic;
using System.Linq;
using Source.Data;
using Source.Services;
using Source.Simulation.Settings;
using NanoEcs;
using UnityEngine;
using Zenject;

namespace Source.Simulation.Systems
{
    public class CreateSystem : SystemEcs, Iinitializable
    {
        #region Dependencies
        [Inject] Businesses businessSettings;
        [Inject] BusinessService businessService;
        [Inject] PlayerService playerService;
        [Inject] SessionData sessionData;
        
        private readonly Contexts _contexts;
        private readonly GameEntity _player;
        #endregion
        
        
        public CreateSystem(Contexts contexts, GameEntity player)
        {
            _contexts = contexts;
            _player = player;
        }
        
        public void Initialize()
        {
            if (sessionData.HasSessionStateData)
            {
                LoadData();
            }
            else
            {
                CreateData();
            }
        }

        private void CreateData()
        {
            _player.AddBalance(0);
            playerService.RegisterPlayer(_player);
            
            foreach (var business in businessSettings.BusinessesSettings)
            {
                var entity = _contexts.Game.CreateEntity();
                entity.AddSettings(business);
                entity.AddBusinessId(business.BusinessId);
                
                entity.AddIncomeProgress(0);
                if (business.IsUnlockedByDefault)
                {
                    entity.AddLevel(1);
                    entity.IsActive = true;
                }
                else
                {
                    entity.AddLevel(0);
                }
                
                entity.AddIncomeValue(business.BaseIncome);
                entity.AddCost((entity.Level.Value + 1) * business.BaseCost);
                entity.AddBaseIncomeTime(business.BaseIncomeTime);
                entity.AddIncreaseIncomeModifier(1);
                entity.AddReduceIncomeTimeModifier(1);
                businessService.RegisterBusiness(business.BusinessId, entity);
            }
        }

        private void LoadData()
        {
            var stateData = sessionData.StateData;

            _player.AddBalance(stateData.PlayerBalance);
            playerService.RegisterPlayer(_player);

            foreach (var business in stateData.Businesses)
            {
                if (businessSettings.HasBusinessWithId(business.BusinessId))
                {
                    var settings = businessSettings.GetBusinessSettingsWithId(business.BusinessId);
                    var entity = _contexts.Game.CreateEntity();
                    entity.AddSettings(settings);
                    entity.AddBusinessId(business.BusinessId);
                    entity.AddIncomeProgress(business.IncomeProgress);
                    entity.AddLevel(business.Level);
                    if (business.Level >= 1)
                    {
                        entity.IsActive = true;
                    }
                    
                    entity.AddIncomeValue(settings.BaseIncome * business.Level);
                    entity.AddCost((entity.Level.Value + 1) * settings.BaseCost);
                    entity.AddBaseIncomeTime(settings.BaseIncomeTime);
                    entity.AddIncreaseIncomeModifier(1);
                    entity.AddReduceIncomeTimeModifier(1);

                    businessService.RegisterBusiness(business.BusinessId, entity);
                }
            }

            foreach (var modifier in stateData.Modifiers)
            {
                businessService.RegisterModifier(modifier.BusinessId, modifier.ModifierId);
            }
        }
    }
}