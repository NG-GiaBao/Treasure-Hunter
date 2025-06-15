using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenHealBarPlayer : BaseScreen
{
    [SerializeField] private Slider healBarSlider;
    [SerializeField] private TextMeshProUGUI goldTxt;
    [SerializeField] private RectTransform coinRect;

    private void Start()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.OnSendPlayerHeal, OnEventSendPlayerHeal);
            ListenerManager.Instance.BroadCast(ListenType.OnSendRectItem, (coinRect,ItemType.Coin));
            ListenerManager.Instance.Register(ListenType.OnSendItemValue, OnEventSendItemValue);
        }
        if (GameManager.HasInstance)
        {
            int coin = GameManager.Instance.GetItemValue(ItemType.Coin);
            goldTxt.text = $"x {coin}";
        }

    }
    private void OnDestroy()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Unregister(ListenType.OnSendPlayerHeal, OnEventSendPlayerHeal);
            ListenerManager.Instance.Unregister(ListenType.OnSendItemValue, OnEventSendItemValue);
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
    private void OnEventSendItemValue(object value)
    {
        if (value is (ItemType itemType, int amount) && itemType == ItemType.Coin)
        {
            goldTxt.text = $"x {amount}";
        }
    }
}
