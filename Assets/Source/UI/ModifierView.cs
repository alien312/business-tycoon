using System;
using Source.Data.Modifiers;
using Source.Services;
using TMPro;
using UniRx;
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
        [SerializeField] private GameObject activeState;
        [SerializeField] private GameObject boughtState;
        #endregion
        
        private BusinessService _businessService;
        private ModifierInfo _info;
        private ColorBlock _boughtState;
        private CompositeDisposable _buttonInteractableDisposable;
        
        
        internal virtual void Initialize(ModifierInfo info, PlayerService playerService, BusinessService businessService)
        {
            _info = info;
            _businessService = businessService;
            
            titleText.text = info.Title;
            costText.text = $"{info.Cost}$";
            
            _buttonInteractableDisposable = new CompositeDisposable();
            _businessService.ModifierApplied += UpdateView;
            
            button.onClick.AddListener(OnButtonClicked);
            playerService.BalanceStream
                .Subscribe(_ => 
                { 
                    button.interactable = _businessService.CanBuyModifier(info.BusinessId, info.Id); 
                })
                .AddTo(_buttonInteractableDisposable);
        }

        private void OnButtonClicked()
        {
            _businessService.RegisterModifier(_info.BusinessId, _info.Id);
        }

        private void UpdateView(string businessId, string modId)
        {
            if(!(businessId.Equals(_info.BusinessId) && modId.Equals(_info.Id))) return;
            
            button.interactable = false;
            button.colors = _boughtState;
            activeState.SetActive(false);
            boughtState.SetActive(true);
            
            _buttonInteractableDisposable.Dispose();
        }

        internal void SetColors(ColorBlock boughtState)
        {
            _boughtState = boughtState;
        }
    }
}