using System.Linq;
using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "Businesses", menuName = "GameSettings/Businesses", order = 0)]
    public class Businesses : ScriptableObject
    {
        [SerializeField] private BusinessSettings[] businessesSettings;

        public BusinessSettings[] BusinessesSettings => businessesSettings;

        public bool HasBusinessWithId(string businessId)
        {
            return businessesSettings.Count(b => b.BusinessId.Equals(businessId)) != 0;
        }

        public BusinessSettings GetBusinessSettingsWithId(string id)
        {
            return businessesSettings.First(b => b.BusinessId.Equals(id));
        }
    }
}