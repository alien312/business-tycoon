using System.Collections.Generic;
using NanoEcs;
using Source.Simulation.Settings;
using Source.UI;
using UnityEngine;
using Zenject;

public class MainWindow : MonoBehaviour, Iinitializable
{
    [SerializeField] private Transform container;
    
    [Inject] UiFactory uiFactory;
    [Inject] UiSettings settings;
    [Inject] Contexts contexts;
    [Inject] GameGroup businessesGroup; 

    private List<BusinessView> _businessViews = new List<BusinessView>();
    
    private void Start()
    {
        foreach (var business in businessesGroup)
        {
            var id = business.BusinessId.Value;
            var uiSettings = settings.GetBusinessUiSettings(id);
            if (uiSettings != null)
            {
                _businessViews.Add(uiFactory.CreateBusinessView(settings.BusinessViewPrefab, container, uiSettings, business)); 
            }
        }
    }

    public void Initialize()
    {
        Debug.Log("hz");
    }
}