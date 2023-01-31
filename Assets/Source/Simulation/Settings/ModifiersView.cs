using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "ModifiersView", menuName = "GameSettings/ModifiersView", order = 0)]
    public class ModifiersView : ScriptableObject
    {
        [field: SerializeField] public ModifierViewSettings IncreaseIncomeModifierViewSettings { get; private set; }
        [field: SerializeField] public ModifierViewSettings ReduceIncomeTimeModifierViewSettings { get; private set; }
    }
}