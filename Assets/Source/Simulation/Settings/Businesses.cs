using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "Businesses", menuName = "GameSettings/Businesses", order = 0)]
    public class Businesses : ScriptableObject
    {
        [SerializeField] private BusinessSettings[] businessesSettings;

        public BusinessSettings[] BusinessesSettings => businessesSettings;
    }
}