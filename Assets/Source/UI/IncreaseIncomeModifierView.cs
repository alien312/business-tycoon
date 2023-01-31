using Source.Data.Modifiers;
using Source.Services;
using TMPro;
using UnityEngine;

namespace Source.UI
{
    public class IncreaseIncomeModifierView : ModifierView
    {
        [SerializeField] private TMP_Text effectText;

        private BusinessService _businessService;
        private PlayerService _playerService;
        private IncreaseIncomeModifierInfo _modifierInfo;
        
        internal override void Initialize(ModifierInfo info, PlayerService playerService, BusinessService businessService)
        {
            base.Initialize(info, playerService, businessService);

            _modifierInfo = (IncreaseIncomeModifierInfo) info;
            effectText.text = $"+ {_modifierInfo.Value * 100}%";
        }
    }
}