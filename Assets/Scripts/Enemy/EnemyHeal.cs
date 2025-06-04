using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHeal : MonoBehaviour
{
    [SerializeField] private EnemyStatSO m_EnemystatSO;
    [SerializeField] private int m_EnemyHeal;

    [SerializeField] private Animator m_EnemyAnimator;
    [SerializeField] private EnemyDeath m_EnemyDeath;
    private void Awake()
    {
        m_EnemyAnimator = GetComponent<Animator>();
        m_EnemyDeath = GetComponent<EnemyDeath>();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_EnemyHeal = m_EnemystatSO.EnemyHealth;
        NewPlayerDealsDamage.OnPlayerDamage += UpdateHeal;
    }
    private void OnDestroy()
    {
        NewPlayerDealsDamage.OnPlayerDamage -= UpdateHeal;
    }

    private void UpdateHeal(int PlayerDamage , GameObject gameObject)
    {
        if(gameObject == this.gameObject)
        {
            m_EnemyAnimator.SetTrigger("Hit");
            m_EnemyHeal -= PlayerDamage;
            EnemyDead();
        }
    }
    public void EnemyDead()
    {
        if (m_EnemyHeal <= 0)
        {
            m_EnemyDeath.EnemyIsDeath();
        }
    }

    public int GetEnemyHeal() => m_EnemyHeal;
}
