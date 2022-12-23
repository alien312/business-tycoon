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
        [SerializeField] private Upgrade[] upgrades;
        [SerializeField] private bool isUnlockedByDefault;

        public string BusinessId => businessID;

        public bool IsUnlockedByDefault => isUnlockedByDefault;
    }

    [Serializable]
    internal struct Upgrade
    {
        [SerializeField] private float cost;
        [SerializeField] private float incomeMultiplayer;
    }
}
