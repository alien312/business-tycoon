using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "UiSettings", menuName = "GameSettings/UiSettings", order = 0)]
    public class UiSettings : ScriptableObject
    {
        [SerializeField] private GameObject MainWindow;
        [SerializeField] private BusinessUiSettings[] businessUiSettings;
    }
}