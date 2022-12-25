using System;
using Source.Services;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class BusinessModifierButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text priseText;
        [SerializeField] private TMP_Text incomeText;
        [SerializeField] private Button button;
        [SerializeField] private GameObject activeState;
        [SerializeField] private GameObject boughtState;
        [SerializeField] private ColorBlock boughtColors;

        private BusinessService _businessService;
        private PlayerService _playerService;
        private string _businessId;
        private int _modifierId;
        private CompositeDisposable _buttonInteractableDisposable;
        
        public event Action Clicked;

        internal void Initialize(BusinessService businessService, string businessId, ModifierInfo info, PlayerService playerService)
        {
            _buttonInteractableDisposable = new CompositeDisposable();
            
            _businessService = businessService;
            _businessId = businessId;
            _playerService = playerService;
            _modifierId = info.index;

            titleText.text = info.title;
            priseText.text = info.prise + "$";
            incomeText.text = "+" + (info.multiplayer * 100) + "%";
            
            button.onClick.AddListener(OnBuyModifier);

             _playerService.BalanceStream
                 .Subscribe(_ => 
                 { 
                     button.interactable = _businessService.CanBuyModifier(_businessId, info.index); 
                 })
                .AddTo(_buttonInteractableDisposable);
        }

        private void OnBuyModifier()
        {
            _businessService.ApplyModifier(_businessId, _modifierId);
            Clicked?.Invoke();
            UpdateView();
        }
        
        private void UpdateView()
        {
            _buttonInteractableDisposable.Dispose();
            button.interactable = false;
            button.colors = boughtColors;
            activeState.SetActive(false);
            boughtState.SetActive(true);
        }
    }
}
