using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyDetectedPlayer m_EnemyDetectedPlayer;

    private void Awake()
    {
        m_EnemyDetectedPlayer = GetComponent<EnemyDetectedPlayer>();
    }
}
