using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : BaseManager<QuestManager>
{
    [Header("Value Item")]
    [ShowInInspector]
    private readonly Dictionary<ItemType, int> ItemValue = new();
    private QuestMissionSO currentMission;
    public QuestMissionSO CurrentMission
    {
        get => currentMission;
        set
        {
            currentMission = value;
            if (ListenerManager.HasInstance)
            {
                ListenerManager.Instance.BroadCast(ListenType.OnSendMission, currentMission);
            }
        }
    }

    private void Start()
    {
        InitDict();
    }
    private void InitDict()
    {
        ItemValue.Add(ItemType.Coin, 0);
        ItemValue.Add(ItemType.GreenDiamond, 0);
        ItemValue.Add(ItemType.RedDiamond, 0);
        ItemValue.Add(ItemType.BlueDiamond, 0);
    }
    public void CheckItemMissionComplete(ItemType itemType)
    {
        if (ItemValue.ContainsKey(itemType))
        {
            if (ItemValue[itemType] >= CheckItem(itemType).requestAmount)
            {
                CheckItem(itemType).isComplete = true;
                if (CheckMissionComplete())
                {
                    if(UIManager.HasInstance)
                    {
                        UIManager.Instance.ShowPopup<PopupBoardGameVictory>();
                    }
                }
            }
        }
    }
    private bool CheckMissionComplete()
    {
        for (int i = 0; i < currentMission.missionDataList.Count; i++)
        {
            if (!currentMission.missionDataList[i].isComplete)
            {
                return false;
            }
        }
        return true;
    }
    private MissionData CheckItem(ItemType itemType)
    {
        for (int i = 0; i < currentMission.missionDataList.Count; i++)
        {
            if (currentMission.missionDataList[i].itemType == itemType)
            {
                return currentMission.missionDataList[i];
            }
        }
        return null;
    }
    public void AddItemValue(ItemType itemType, int amout = 1)
    {
        if (ItemValue.ContainsKey(itemType))
        {
            ItemValue[itemType] += amout;
            if (ListenerManager.HasInstance)
            {
                ListenerManager.Instance.BroadCast(ListenType.OnSendItemValue, (itemType, ItemValue[itemType]));
            }
        }
        else
        {
            Debug.LogError($"ItemType {itemType} not found in ItemValue dictionary.");
        }
    }
    public int GetItemValue(ItemType itemType)
    {
        if (ItemValue.ContainsKey(itemType))
        {
            return ItemValue[itemType];
        }
        else
        {
            Debug.LogError($"ItemType {itemType} not found in ItemValue dictionary.");
            return 0;
        }
    }
    public void SetCurrentMission(QuestMission mission)
    {
        if (DataManager.HasInstance)
        {
            currentMission = DataManager.Instance.GetMission(mission);
        }
        if (currentMission != null)
        {
            Debug.Log($"Current mission set to: {currentMission.questMission}");
        }
        else
        {
            Debug.LogError($"Failed to set current mission: {mission}");
        }
    }

}
