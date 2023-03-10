using NanoEcs;
using UnityEngine;

namespace Source.Simulation.Systems
{
    public class ProgressSystem : SystemEcs, IExecutable
    {
        
        private readonly GameGroup _activeBusinesses;
        private  Contexts _contexts;
        private float delta => Time.deltaTime;

        public ProgressSystem(GameGroup businesses, Contexts contexts)
        {
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