using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int m_EnemyDamage;
   
    public int GetEnemyDamage()
    {
        return m_EnemyDamage;
    }
}
