using System.Collections.Generic;
using NanoEcs;
using Source.Simulation.Settings;
using Source.UI;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class MainWindow : MonoBehaviour, Iinitializable
{
    #region ViewLinks
    [SerializeField] private Transform container;
    [SerializeField] private TMP_Text BalanceValue;
    [SerializeField] UnityEngine.UI.ScrollRect ElementsScroll;
    #endregion
    
    #region State
    [Inject] UiFactory uiFactory;
    [Inject] UiSettings settings;
    [Inject] GameEntity player;
    [Inject] GameGroup businessesGroup; 
    #endregion
    

    private List<BusinessView> _businessViews = new List<BusinessView>();
    
    private void Start()
    {
        player
            .ObserveEveryValueChanged(e => e.Balance.Value)
            .Subscribe(value =>
            {
                BalanceValue.text = value.ToString();
            })
            .AddTo(this);
        
        foreach (var business in businessesGroup)
        {
            var id = business.BusinessId.Value;
            var uiSettings = settings.GetBusinessUiSettings(id);
            if (uiSettings != null)
            {
                _businessViews.Add(uiFactory.CreateBusinessUiItem(settings.BusinessViewPrefab, container, uiSettings, id)); 
            }
        }

        ElementsScroll.verticalNormalizedPosition = 1;
    }

    public void Initialize()
    {
    }
}