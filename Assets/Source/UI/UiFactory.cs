using Source.Simulation.Settings;
using UnityEngine;

namespace Source.UI
{
    public class UiFactory
    {
        public BusinessView CreateBusinessView(GameObject prefab, Transform parent, BusinessUiSettings uiSettings, GameEntity business)
        {
            var view = GameObject.Instantiate(prefab, parent).GetComponent<BusinessView>();
            view.Initialize(uiSettings, business);
            return view;
        }
    }
}