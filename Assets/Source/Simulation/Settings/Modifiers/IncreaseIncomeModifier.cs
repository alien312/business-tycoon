using System;
using UnityEngine;

namespace Source.Simulation.Settings.Modifiers
{
    [Serializable]
    public class IncreaseIncomeModifier : Modifier
    {
        [SerializeField] public float value;
    }
}