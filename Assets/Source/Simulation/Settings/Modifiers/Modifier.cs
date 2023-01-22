using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Source.Simulation.Settings.Modifiers
{
    [Serializable]
    public class Modifier
    {
        [SerializeField, HideInInspector] private string name;
        [SerializeField] private float cost;

        public Modifier()
        {
            SetModifierName();
        }

        public void SetModifierName() => name = Regex.Replace(GetType().Name, "([^^])([A-Z])", "$1 $2");
    }
}