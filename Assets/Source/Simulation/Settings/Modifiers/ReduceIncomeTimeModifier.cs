using System;
using UnityEngine;

namespace Source.Simulation.Settings.Modifiers
{
    [Serializable]
    public class ReduceIncomeTimeModifier : Modifier
    {
        [field: SerializeField] public float Value { get; private set; }
    }
}