using System.Linq;
using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "UiSettings", menuName = "GameSettings/UiSettings", order = 0)]
    public class UiSettings : ScriptableObject
    {
        [SerializeField] private GameObject mainWindow;
        [SerializeField] private GameObject businessViewPrefab;
        [SerializeField] private BusinessUiSettings[] businessUiSettings;

        public GameObject MainWindow => mainWindow;

        public GameObject BusinessViewPrefab => businessViewPrefab;

        public BusinessUiSettings GetBusinessUiSettings(string businessId)
        {
            return businessUiSettings.FirstOrDefault(b => b.BusinessID.Equals(businessId));
        }
    }
}