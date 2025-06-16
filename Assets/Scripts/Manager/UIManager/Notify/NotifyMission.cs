using DG.Tweening;
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
        if(ListenerManager.HasInstance)
        {
            ListenerManager.Instance.BroadCast(ListenType.OnSendRectItem, (redDiamondRect,ItemType.RedDiamond));
            ListenerManager.Instance.BroadCast(ListenType.OnSendRectItem, (greenDiamondRect,ItemType.GreenDiamond));
            ListenerManager.Instance.BroadCast(ListenType.OnSendRectItem, (blueDiamondRect,ItemType.BlueDiamond));
            ListenerManager.Instance.Register(ListenType.OnSendItemValue, OnEventSendItemValue);
            ListenerManager.Instance.Register(ListenType.OnSendMission, OnEventSendMission);
        }
    }
    private void OnDestroy()
    {
        if(ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Unregister(ListenType.OnSendItemValue, OnEventSendItemValue);
            ListenerManager.Instance.Unregister(ListenType.OnSendMission, OnEventSendMission);
        }
       
    }
    private void OnEventSendItemValue(object value)
    {
        if (value is (ItemType itemType, int amount))
        {
            switch (itemType)
            {
                case ItemType.RedDiamond:
                    redDiamond.text = $"x {amount}";
                    break;
                case ItemType.BlueDiamond:
                    blueDiamond.text = $"x {amount}";
                    break;
                case ItemType.GreenDiamond:
                    greenDiamond.text = $"x {amount}";
                    break;
            }
        }
    }
    private void OnEventSendMission(object value)
    {
        if (value is QuestMissionSO mission)
        {
            for(int i=0;i<mission.missionDataList.Count;i++)
            {
                MissionData data = mission.missionDataList[i];
                switch(data.itemType)
                {
                    case ItemType.RedDiamond:
                        UpdateText(redDiamond, data.requestAmount,0);
                        break;
                    case ItemType.BlueDiamond:
                        UpdateText(blueDiamond, data.requestAmount, 0);
                        break;
                    case ItemType.GreenDiamond:
                        UpdateText(greenDiamond, data.requestAmount, 0);
                        break;
                }
            }
           
        }
    }
    private void UpdateText(TextMeshProUGUI text,int requestAmount,int completeAmount)
    {
        text.text = $"{completeAmount} / {requestAmount}";
    }
}
