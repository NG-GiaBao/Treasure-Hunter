using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetParent : MonoBehaviour
{
    [SerializeField] private Transform[] m_PointMove;
    void Start()
    {
        SetParentPoints();
    }
    private void SetParentPoints()
    {
        foreach (Transform transform in m_PointMove)
        {
            transform.SetParent(null);
        }
    }
}
