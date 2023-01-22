using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public abstract class ModifierView : MonoBehaviour
    {
        #region ViewLinks
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text costText;
        [SerializeField] private Button button;
        #endregion
        
        public event Action Clicked;
        
        
        internal virtual void Initialize(string title, string cost)
        {
            titleText.text = title;
            costText.text = cost + "$";
            
            button.onClick.AddListener(() => Clicked?.Invoke());
        }
    }
}