using Source.Simulation.Settings;
using TMPro;
using UnityEngine;

namespace Source.UI
{
    public class BusinessView : MonoBehaviour
    {
        #region ViewLinks
        [SerializeField] private TMP_Text title;
        [SerializeField] private TMP_Text level;
        [SerializeField] private TMP_Text income;
        #endregion
        public void Initialize(BusinessUiSettings uiSettings, GameEntity business)
        {
            var settings = (BusinessSettings) business.Settings.Value;
            title.text = uiSettings.TitleValue;
        }
    }
}