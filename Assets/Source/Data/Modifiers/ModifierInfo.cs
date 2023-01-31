using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Source.Data.Modifiers
{
    [Serializable]
    public class ModifierInfo
    {
        [SerializeField, HideInInspector] private string name;
        [field: SerializeField, HideInInspector] public string BusinessId { get; set; }
        
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public float Cost { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        
        public ModifierInfo()
        {
            SetModifierName();
        }

        public void SetModifierName() => name = Regex.Replace(GetType().Name, "([^^])([A-Z])", "$1 $2");
    }
}