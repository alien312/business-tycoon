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
        #endregion
        
        public BusinessView CreateBusinessUiItem(GameObject prefab, Transform parent, BusinessUiSettings uiSettings, string businessId)
        {
            var view = GameObject.Instantiate(prefab, parent).GetComponent<BusinessView>();
            view.Initialize(uiSettings, _businessService, businessId, _playerService);
            return view;
        }
    }
}