using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHeal : MonoBehaviour
{
    [SerializeField] private TrapStatSO m_TrapHealSO;
    [SerializeField] private int m_TrapHeal;
    [SerializeField] private TrapController m_TrapController;
    private void Awake()
    {
        m_TrapController = GetComponent<TrapController>();

    }

    private void Start()
    {
        m_TrapHeal = m_TrapHealSO.TrapHealth;
        NewPlayerDealsDamage.OnPlayerDamage += EnemyRecieverDamage;
    }

    private void OnDestroy()
    {
        NewPlayerDealsDamage.OnPlayerDamage -= EnemyRecieverDamage;
    }

    private void EnemyRecieverDamage(int damage, GameObject targetObject)
    {
        if (targetObject == gameObject)
        {
            
            m_TrapHeal -= damage;
            if (m_TrapHeal <= 0)
            {
                //OnTrapDestroyed?.Invoke();
                m_TrapController.m_Destroyed.DestroyTrap();
            }
        }
    }
    public int GetEnemyHealth()
    {
        return m_TrapHeal;
    }
}
