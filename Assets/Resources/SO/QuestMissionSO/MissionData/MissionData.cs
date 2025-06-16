using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "MissionData", menuName = "Scriptable Objects/MissionData", order = 2)]
public class MissionData : ScriptableObject
{
    public ItemType itemType;
    [PreviewField(100, ObjectFieldAlignment.Center)]
    public Sprite icon;
    public string itemName;
    public int requestAmount;
    public bool isComplete;
}
