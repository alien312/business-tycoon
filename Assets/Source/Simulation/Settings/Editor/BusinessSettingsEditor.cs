using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Source.Data.Modifiers;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Source.Simulation.Settings
{
    [CustomEditor(typeof(BusinessSettings))]
    public class BusinessSettingsEditor : Editor
    {
        private static List<Type> _modifierTypes = new List<Type>();
        private BusinessSettings _businessSettings;

        private void OnEnable()
        {
            _businessSettings = (BusinessSettings) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var modifierType in _modifierTypes)
            {
                if (GUILayout.Button(Regex.Replace(modifierType.Name, "([^^])([A-Z])", "$1 $2")))
                {
                    var comp = (ModifierInfo) Activator.CreateInstance(modifierType); 
                    
                    if(comp == null) return;
                    comp.BusinessId = _businessSettings.BusinessId;
                    _businessSettings.AddModifier(comp);
                }
            }
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            _modifierTypes = assemblies.SelectMany(assembly => assembly.GetTypes()).Where(t=>t.IsSubclassOf(typeof(ModifierInfo))).ToList();
        }
    }
}