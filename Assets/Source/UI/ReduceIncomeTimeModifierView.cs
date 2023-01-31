using Source.Data.Modifiers;
using Source.Services;
using TMPro;
using UnityEngine;

namespace Source.UI
{
    public class ReduceIncomeTimeModifierView : ModifierView
    {
        [SerializeField] private TMP_Text effectText;

        private BusinessService _businessService;
        private PlayerService _playerService;
        private ReduceIncomeTimeModifierInfo _modifierInfo;
        
        internal override void Initialize(ModifierInfo info, PlayerService playerService, BusinessService businessService)
        {
            base.Initialize(info, playerService, businessService);

            _modifierInfo = (ReduceIncomeTimeModifierInfo) info;
            effectText.text = $"- {1 + _modifierInfo.Value}X";
        }
    }
}