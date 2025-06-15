using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotifyMission : BaseNotify
{
    [SerializeField] private TextMeshProUGUI redDiamond;
    [SerializeField] private RectTransform redDiamondRect;
    [SerializeField] private TextMeshProUGUI blueDiamond;
    [SerializeField] private RectTransform blueDiamondRect;
    [SerializeField] private TextMeshProUGUI greenDiamond;
    [SerializeField] private RectTransform greenDiamondRect;

    // Start is called before the first frame update
    void Start()
    {

        if (TryGetComponent<RectTransform>(out var rectTransform))
        {
            rectTransform.DOScale(Vector3.one, 1f).From(Vector3.zero).SetEase(Ease.OutBack);
        }
        if(GameManager.HasInstance)
        {
            int red = GameManager.Instance.GetItemValue(ItemType.RedDiamond);
            int blue = GameManager.Instance.GetItemValue(ItemType.BlueDiamond);
            int green = GameManager.Instance.GetItemValue(ItemType.GreenDiamond);
            redDiamond.text = $"x {red}";
            blueDiamond.text = $"x {blue}";
            greenDiamond.text = $"x {green}";
        }
        if(ListenerManager.HasInstance)
        {
            ListenerManager.Instance.BroadCast(ListenType.OnSendRectItem, (redDiamondRect,ItemType.RedDiamond));
            ListenerManager.Instance.BroadCast(ListenType.OnSendRectItem, (greenDiamondRect,ItemType.GreenDiamond));
            ListenerManager.Instance.BroadCast(ListenType.OnSendRectItem, (blueDiamondRect,ItemType.BlueDiamond));
        }
    }
}
