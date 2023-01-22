using System;
using System.Collections.Generic;
using Source.Simulation.Settings.Modifiers;
using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "BusinessSettings", menuName = "GameSettings/BusinessSettings")]
    public class BusinessSettings : ScriptableObject
    {
        [SerializeField] private string businessID;
        [SerializeField] private float incomeTime;
        [SerializeField] private float baseCost;
        [SerializeField] private float baseIncome;
        [SerializeField] private ModifierOld[] modifiers;
        [field: SerializeReference] public List<Modifier> Modifiers { get; private set; }
        [SerializeField] private bool isUnlockedByDefault;

        #region Editor
        public void AddModifier(Modifier modifier)
        {
            Modifiers.Add(modifier);
        }
        #endregion
        
        public bool IsUnlockedByDefault => isUnlockedByDefault;
        
        public string BusinessId => businessID;
        public float BaseIncome => baseIncome;
        public float BaseCost => baseCost;
        public float IncomeTime => incomeTime;
        public int ModifiersCount => modifiers.Length;
        
        public float GetModifierCostOld(int index)
        {
            if (index < ModifiersCount)
            {
                return modifiers[index].cost;
            }

            Debug.LogError("");
            return 0;
        }
        public float GetModifierMultiplayer(int index)
        {
            if (index < ModifiersCount)
            {
                return modifiers[index].incomeMultiplayer;
            }

            Debug.LogError("");
            return 0;
            
        }
    }

    [Serializable]
    internal struct ModifierOld
    {
        [SerializeField] internal float cost;
        [SerializeField] internal float incomeMultiplayer;
    }
}
