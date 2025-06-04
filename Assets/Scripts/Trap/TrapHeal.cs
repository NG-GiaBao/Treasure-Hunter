using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHeal : MonoBehaviour
{
    [SerializeField] private TrapStatSO m_TrapHealSO;
    [SerializeField] private int m_TrapHeal;

    public static event Action<int, GameObject> OnHealthChanged; // Gửi máu và đối tượng trap
    public static event Action<GameObject> OnTrapDestroyed; // Gửi đối tượng khi trap bị phá hủy

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

            // Gửi sự kiện khi máu thay đổi
            OnHealthChanged?.Invoke(m_TrapHeal, gameObject);

            // Nếu máu <= 0, trap bị phá hủy
            if (m_TrapHeal <= 0)
            {
                OnTrapDestroyed?.Invoke(gameObject);
            }
        }
    }
    public int GetEnemyHealth()
    {
        return m_TrapHeal;
    }
}
