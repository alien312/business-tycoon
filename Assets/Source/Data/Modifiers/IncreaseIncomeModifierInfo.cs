using System;
using UnityEngine;

namespace Source.Data.Modifiers
{
    [Serializable]
    public class IncreaseIncomeModifierInfo : ModifierInfo
    {
        [field: SerializeField] public float Value { get; private set; }
    }
}