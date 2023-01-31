using Source.Services;
using Source.Simulation.Settings;
using UnityEngine;
using Zenject;

namespace Source.UI
{
    public class UiFactory
    {
        #region Dependencies
        [Inject] private BusinessService _businessService;
        [Inject] private PlayerService _playerService;
        [Inject] private ModifiersView _modifiersView;
        #endregion
        
        public BusinessView CreateBusinessUiItem(GameObject prefab, Transform parent, GameEntity entity)
        {
            var view = GameObject.Instantiate(prefab, parent).GetComponent<BusinessView>();
            view.Initialize(entity, _businessService, _playerService, _modifiersView );
            return view;
        }
    }
}