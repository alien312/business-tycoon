using System;
using Source.Services;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class IncreaseIncomeModifierView : ModifierView
    {
        [SerializeField] private TMP_Text effectText;
        [SerializeField] private GameObject activeState;
        [SerializeField] private GameObject boughtState;
        [SerializeField] private ColorBlock boughtColors;
        
        private BusinessService _businessService;
        private PlayerService _playerService;
        private string _businessId;
        private int _modifierId;
        private CompositeDisposable _buttonInteractableDisposable;
        
        internal override void Initialize(string title, string cost)
        {
            base.Initialize(title, cost);
            
            /*_businessService = businessService;
            _businessId = businessId;
            _playerService = playerService;
            _modifierId = info.index;
            
            priseText.text = info.prise + "$";*/
            effectText.text = "+" + (/*info.multiplayer*/1 * 100) + "%";
            
            _buttonInteractableDisposable = new CompositeDisposable();

            /*if (!info.isBought)
            {
                _playerService.BalanceStream
                    .Subscribe(_ => 
                    { 
                        button.interactable = _businessService.CanBuyModifier(_businessId, info.index); 
                    })
                    .AddTo(_buttonInteractableDisposable);
            }
            else
            {
                UpdateView();
            }*/
             
        }

        private void OnBuyModifier()
        {
            _businessService.ApplyModifier(_businessId, _modifierId);
            //Clicked?.Invoke();
            UpdateView();
        }
        
        private void UpdateView()
        {
            _buttonInteractableDisposable.Dispose();
            //button.interactable = false;
            //button.colors = boughtColors;
            activeState.SetActive(false);
            boughtState.SetActive(true);
        }
    }
}