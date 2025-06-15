using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapType : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    public ItemType ItemType
    {
        get => itemType;
    }
}
