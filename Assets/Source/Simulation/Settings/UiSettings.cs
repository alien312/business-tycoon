using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "UiSettings", menuName = "GameSettings/UiSettings", order = 0)]
    public class UiSettings : ScriptableObject
    {
        [field: SerializeField] public GameObject MainWindow { get; private set; }
        [field: SerializeField] public GameObject BusinessViewPrefab { get; private set; }
        [field: SerializeField] public ModifiersView ModifiersView { get; private set; }
    }
}