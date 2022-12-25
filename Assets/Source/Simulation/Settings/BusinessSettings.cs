using System;
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
        [SerializeField] private Modifier[] modifiers;
        [SerializeField] private bool isUnlockedByDefault;
        

        public bool IsUnlockedByDefault => isUnlockedByDefault;
        
        public string BusinessId => businessID;
        public float BaseIncome => baseIncome;
        public float BaseCost => baseCost;
        public float IncomeTime => incomeTime;

        public float GetModifierCost(int index)
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
        public int ModifiersCount => modifiers.Length;
    }

    [Serializable]
    internal struct Modifier
    {
        [SerializeField] internal float cost;
        [SerializeField] internal float incomeMultiplayer;
    }
}
