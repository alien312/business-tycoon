using System.Text;
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

        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private BusinessSettings _businessSettings;
        
        public void Initialize(BusinessUiSettings uiSettings, GameEntity business)
        {
            _businessSettings = (BusinessSettings) business.Settings.Value;
            title.text = uiSettings.TitleValue;
            level.text = business.Level.Value.ToString();
            income.text = business.IncomeValue.Value + "$";
        }
    }
}