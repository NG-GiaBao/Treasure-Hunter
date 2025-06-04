using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private Animator m_EnemyAnimator;
    [SerializeField] private EnemyHeal m_EnemyHeal;
    [SerializeField] private Rigidbody2D m_EnemyRb;
    [SerializeField] private Vector2 m_Force;
    [SerializeField] private bool m_EnemyDead;

    private void Awake()
    {
        m_EnemyAnimator = GetComponent<Animator>();
        m_EnemyHeal = GetComponent<EnemyHeal>();
        m_EnemyRb = GetComponent<Rigidbody2D>();
    }
    public void EnemyIsDeath()
    {
        m_EnemyDead = true;
        m_EnemyAnimator.SetTrigger("Death");
        m_EnemyRb.velocity = new Vector2(m_Force.x * transform.localScale.x, m_Force.y * transform.localScale.y);
    }
    public bool GetStateEnemyDead() => m_EnemyDead;
}
