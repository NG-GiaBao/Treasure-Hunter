using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenHealBarPlayer : BaseScreen
{
    [SerializeField] private Slider healBarSlider;
    [SerializeField] private TextMeshProUGUI goldTxt;

    private void Start()
    {
       if(ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.OnSendPlayerHeal, OnEventSendPlayerHeal);
        }
    }
    private void OnDestroy()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Unregister(ListenType.OnSendPlayerHeal, OnEventSendPlayerHeal);
        }
    }
    private void OnEventSendPlayerHeal(object value)
    {
        if (value is float healValue)
        {
            healBarSlider.maxValue = healValue;
            healBarSlider.value = healValue;
        }
    }
}
