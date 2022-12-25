using UnityEngine;

namespace Source.Simulation.Settings
{
    [CreateAssetMenu(fileName = "BusinessUiSettings", menuName = "GameSettings/BusinessUiSettings", order = 0)]
    public class BusinessUiSettings : ScriptableObject
    {
        [SerializeField] private string businessID;
        [SerializeField] private string titleValue;
        [SerializeField] private GameObject modifierButtonPrefab;
        [SerializeField] private string[] modifierTitles;


        public string BusinessID => businessID;
        public string TitleValue => titleValue;
        public GameObject ModifierButtonPrefab => modifierButtonPrefab;
        
        public string GetModifierTitle(int index)
        {
            if (index < modifierTitles.Length)
            {
                return modifierTitles[index];
            }

            return null;
        }
    }
}