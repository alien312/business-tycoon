using Source.Data.Modifiers;
using Source.Services;
using Source.Simulation.Settings;
using Source.Simulation.Root;
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
        private int _businessHC;
        private string _businessID;
        #endregion
        
        public void Initialize(GameEntity business, BusinessService businessService, PlayerService playerService, ModifiersView modifiersView)
        {
            _businessService = businessService;
            _playerService = playerService;

            var settings = business.Settings<BusinessSettings>();
            _businessID = settings.BusinessId;

            titleText.text = settings.Title;
            
            levelUpdateButton.onClick.AddListener(OnLevelUpdateButtonClick);
            
            business
                .ObserveEveryValueChanged(b => b.IncomeProgress.Value / business.BaseIncomeTime.Value)
                .Subscribe(v =>
                {
                    progress.fillAmount = v;
                })
                .AddTo(this);

            business
                .ObserveEveryValueChanged(b => b.Level.Value)
                .Subscribe(l =>
                {
                    levelText.text = l.ToString();
                });
            
            business
                .ObserveEveryValueChanged(b => b.IncomeValue.Value)
                .Subscribe(v =>
                {
                    incomeText.text = $"{v}$";
                });
            
            business
                .ObserveEveryValueChanged(b => b.Cost.Value)
                .Subscribe(v =>
                {
                    levelUpdateCostText.text = $"{v}$";
                });

            _playerService.BalanceStream
                .Subscribe(value => 
                { 
                    levelUpdateButton.interactable = _businessService.CanBuyLevelUpdate(_businessID); 
                })
                .AddTo(this);

            foreach (var modifierInfo in settings.Modifiers)
            {
                switch (modifierInfo)
                {
                    case IncreaseIncomeModifierInfo:
                        CreateButton<IncreaseIncomeModifierView>(modifiersView.IncreaseIncomeModifierViewSettings, modifierInfo);
                        break;
                    case ReduceIncomeTimeModifierInfo:
                        CreateButton<ReduceIncomeTimeModifierView>(modifiersView.ReduceIncomeTimeModifierViewSettings, modifierInfo);
                        break;
                }
                
            }
        }
        
        private void OnLevelUpdateButtonClick()
        {
            _businessService.UpdateBusinessLevel(_businessID);
        }
        
        private void CreateButton<T>(ModifierViewSettings modifierViewSettings, ModifierInfo modifierInfo) where T : ModifierView
        {
            var modifierButton = Instantiate(modifierViewSettings.IncreaseIncomeModifierGO, modifierButtonsRoot)
                .GetComponent<T>();
            modifierButton.SetColors(modifierViewSettings.BoughtStateColor);
            modifierButton.Initialize(modifierInfo, _playerService, _businessService);
        }
    }
}