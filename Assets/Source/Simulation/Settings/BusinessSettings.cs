using System.Collections.Generic;
using System.Linq;
using Source.Data.Modifiers;
using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "BusinessSettings", menuName = "GameSettings/BusinessSettings")]
    public class BusinessSettings : ScriptableObject
    {
        [field: SerializeField] public string BusinessId { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public float BaseIncomeTime { get; private set; }
        [field: SerializeField] public float BaseCost { get; private set; }
        [field: SerializeField] public float BaseIncome { get; private set; }
        [field: SerializeField] public bool IsUnlockedByDefault { get; private set; }
        [field: SerializeReference] public List<ModifierInfo> Modifiers { get; private set; } = new List<ModifierInfo>();
        
        public ModifierInfo GetModifierInfo(string id)
        {
            if (Modifiers.Select(m => m.Id).Contains(id))
            {
                return Modifiers.First(m => m.Id.Equals(id));
            }
            Debug.Log($"Modifier with id: {id} does not exist");
            return null;
        }
        
        #region Editor
        public void AddModifier(ModifierInfo modifierInfo)
        {
            Modifiers.Add(modifierInfo);
        }
        #endregion
    }
}
