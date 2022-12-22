using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "CoreSettings", menuName = "GameSettings/CoreSettings", order = 0)]
    public class CoreSettings : ScriptableObject
    {
        [SerializeField] private Businesses business;
        [SerializeField] private BusinessUiSettings businessUiSettings;

        public Businesses Businesses => business;
    }
}