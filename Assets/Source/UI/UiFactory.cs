using Source.Services;
using Source.Simulation.Settings;
using UnityEngine;
using Zenject;

namespace Source.UI
{
    public class UiFactory
    {
        [Inject] private BusinessService _businessService;
        [Inject] private PlayerService _playerService;
        
        private GameEntity _player;

        public UiFactory(GameEntity player)
        {
            _player = player;
        }
        
        public BusinessView CreateBusinessUiItem(GameObject prefab, Transform parent, BusinessUiSettings uiSettings, string businessId)
        {
            var view = GameObject.Instantiate(prefab, parent).GetComponent<BusinessView>();
            view.Initialize(uiSettings, _businessService, businessId, _playerService);
            return view;
        }
    }
}