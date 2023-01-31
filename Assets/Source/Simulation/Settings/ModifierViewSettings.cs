using UnityEngine;
using UnityEngine.UI;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "ModifierViewSettings", menuName = "GameSettings/ModifierViewSettings", order = 0)]
    public class ModifierViewSettings : ScriptableObject
    {
        [field: SerializeField] public GameObject IncreaseIncomeModifierGO { get; private set; }
        [field: SerializeField] public ColorBlock BoughtStateColor { get; private set; }
    }
}