using System;
using NanoEcs;
using UnityEngine;

namespace Source.Simulation.Systems
{
    public class ProgressSystem : SystemEcs, IExecutable
    {
        private float delta => Time.deltaTime;
        private GameGroup _businesses;
        private GameGroup _activeBusinesses;
        private  Contexts _contexts;

        public ProgressSystem(GameGroup businesses, Contexts contexts)
        {
            _businesses = businesses;
            _contexts = contexts;
            
            _activeBusinesses = _contexts.Game.GetGroup()
                .With.BusinessId
                .With.Active;
        }
        
        public void Execute()
        {
            foreach (var business in _activeBusinesses)
            {
                business.IncomeProgress.Value += delta;
            }
        }

        
    }
}