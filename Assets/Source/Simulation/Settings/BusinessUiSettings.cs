using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "BusinessUiSettings", menuName = "GameSettings/BusinessUiSettings", order = 0)]
    public class BusinessUiSettings : ScriptableObject
    {
        [SerializeField] private string businessID;
        [SerializeField] private string titleValue;
        [SerializeField] private string[] modifierTitles;
    }
}