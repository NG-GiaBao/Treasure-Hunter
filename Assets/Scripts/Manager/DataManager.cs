using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : BaseManager<DataManager>
{
    [ShowInInspector]
    private readonly Dictionary<QuestMission, QuestMissionSO> missionDict = new();
    private const string PATH_QUEST_MISSION = "SO/QuestMissionSO";

    private void Start()
    {
        InitDict();
    }
    private void InitDict()
    {
        foreach(var mission in Resources.LoadAll<QuestMissionSO>(PATH_QUEST_MISSION))
        {
            if (!missionDict.ContainsKey(mission.questMission))
            {
                missionDict.Add(mission.questMission, mission);
            }
            else Debug.LogWarning(CheckInstance() + " already contains a mission with the same key: " + mission.questMission);
        }
    }
    public QuestMissionSO GetMission(QuestMission questMission)
    {
        if (missionDict.TryGetValue(questMission, out var mission))
        {
            return mission;
        }
        else
        {
            Debug.LogWarning($"No mission found for {questMission}");
            return null;
        }
    }
}
