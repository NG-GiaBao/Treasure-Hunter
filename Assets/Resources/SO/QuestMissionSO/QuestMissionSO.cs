using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestMission
{
    Default = 0,
    firstMission = 1,
    secondMission = 2,
    thirdMission = 3,
    fourthMission = 4,
    fifthMission = 5,
    sixthMission = 6,
    seventhMission = 7,
    eighthMission = 8,
    ninthMission = 9,
    tenthMission = 10,
    eleventhMission = 11,
}

[System.Serializable]
[CreateAssetMenu(fileName = "QuestMissionSO", menuName = "Scriptable Objects/QuestMissionSO", order = 1)]
public class QuestMissionSO : ScriptableObject
{
    public QuestMission questMission;
    [InlineEditor]
    public List<MissionData> missionDataList;
    public bool IsCompleted;
  

}
