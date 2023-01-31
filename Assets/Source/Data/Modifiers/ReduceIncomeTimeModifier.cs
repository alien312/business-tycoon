using System;
using UnityEngine;

namespace Source.Data.Modifiers
{
    [Serializable]
    public class ReduceIncomeTimeModifierInfo : ModifierInfo
    {
        [field: SerializeField] public float Value { get; private set; }
    }
}