using Source.Services;
using Source.Simulation.Settings;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class BusinessView : MonoBehaviour
    {
        #region ViewLinks
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text incomeText;
        [SerializeField] private Button levelUpdateButton;
        [SerializeField] private TMP_Text levelUpdateCostText;
        [SerializeField] private Transform modifierButtonsRoot;
        [SerializeField] private Image progress;
        #endregion

        #region State
        private BusinessService _businessService;
        private PlayerService _playerService;
        private string _businessID;
        #endregion
        
        public void Initialize(BusinessUiSettings uiSettings, BusinessService businessService, string businessId, PlayerService playerService)
        {
            _businessService = businessService;
            _businessID = businessId;
            _playerService = playerService;
            
            titleText.text = uiSettings.TitleValue;
            
            levelUpdateButton.onClick.AddListener(OnLevelUpdateButtonClick);
            
            _businessService.GetBusinessIncomeProgressPercentageStream(_businessID)
                .Subscribe(SetFillAmount)
                .AddTo(this);

            _playerService.BalanceStream
                .Subscribe(value => 
                { 
                    levelUpdateButton.interactable = _businessService.CanBuyLevelUpdate(_businessID); 
                })
                .AddTo(this);

            for (int i = 0; i < _businessService.GetModifiersCount(_businessID); i++)
            {
                var modifierButton = Instantiate(uiSettings.ModifierButtonPrefab, modifierButtonsRoot)
                    .GetComponent<BusinessModifierButton>();
                
                var info = new ModifierInfo()
                {
                    index = i,
                    title = uiSettings.GetModifierTitle(i),
                    prise = _businessService.GetModifierCost(_businessID, i),
                    multiplayer = _businessService.GetModifierMultiplayer(_businessID, i),
                    isBought = _businessService.GetModifierBoughtState(_businessID, i)
                };
                modifierButton.Initialize(_businessService, _businessID, info, _playerService);
                modifierButton.Clicked += UpdateView;
            }
            
            UpdateView();
        }
        
        private void OnLevelUpdateButtonClick()
        {
            _businessService.UpdateBusinessLevel(_businessID);
            UpdateView();
        }
        
        private void UpdateView()
        {
            levelText.text =  _businessService.GetBusinessLevel(_businessID).ToString();
            incomeText.text = _businessService.GetBusinessIncome(_businessID) + "$";
            levelUpdateCostText.text = _businessService.GetBusinessUpdateCost(_businessID) + "$";
        }

        private void SetFillAmount(float fillAmount)
        {
            progress.fillAmount = fillAmount;
        }
    }
}