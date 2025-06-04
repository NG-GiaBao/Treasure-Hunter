using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectedPlayer : TrapDetectedPlayer
{
    [Header("Stat Detec")] 
    [SerializeField] private float m_PlayerDistanceEnemy;
    [SerializeField] private Animator m_EnemyAnimator;
    [SerializeField] private float m_DistanceDetectedPlayer;
    [SerializeField] private float m_ValueEnemyFlipDirection;
    [SerializeField] private bool m_IsDetectedPlayer;

    public static event Action<bool,GameObject> OnIsDetectedPlayer;
    public static event Action<float,GameObject> OnValueEnemyFlipPlayer;

    [SerializeField] private EnemyDeath EnemyDeath;

    private void Awake()
    {
        m_EnemyAnimator = GetComponent<Animator>();
        EnemyDeath = GetComponent<EnemyDeath>();
    }
    // Update is called once per frame
    void Update()
    {
        if(EnemyDeath.GetStateEnemyDead()) return;
        //DetectPlayers();
    }

    public float CalculateDistancePlayer(Vector3 playerPos)
    {
        m_PlayerDistanceEnemy = Vector2.Distance(playerPos, transform.position);
        return m_PlayerDistanceEnemy;
    }
    //public override void DetectPlayers(Vector3 playerPos)
    //{
    //    //if (GameManager.instance.m_IsPlayerDeath)
    //    //{
    //    //    this.enabled = false;
    //    //    return;
    //    //}
    //    //else
    //    //{
    //    //    this.enabled = true;
    //    //}
    //    CalculateDistancePlayer(playerPos);
    //    m_ValueEnemyFlipDirection = playerPos.x - transform.position.x;
    //    if (m_PlayerDistanceEnemy <= m_DistanceDetectedPlayer && m_PlayerDistanceEnemy >= 0)
    //    {
    //        m_IsDetectedPlayer = true;
    //        m_EnemyAnimator.SetBool("IsDected", true);
    //    }
    //    else if (m_PlayerDistanceEnemy > m_DistanceDetectedPlayer)
    //    {
    //        m_IsDetectedPlayer = false;
    //        m_EnemyAnimator.SetBool("IsDected", false);
    //        m_EnemyAnimator.SetBool("IsAttack", false);
    //    }
    //    if (m_PlayerDistanceEnemy >= -m_DistanceDetectedPlayer && m_PlayerDistanceEnemy <= 0)
    //    {
    //        m_IsDetectedPlayer = true;
    //        m_EnemyAnimator.SetBool("IsDected", true);
    //    }
    //    else if (m_PlayerDistanceEnemy < -m_DistanceDetectedPlayer)
    //    {
    //        m_IsDetectedPlayer = false;
    //        m_EnemyAnimator.SetBool("IsDected", false);
    //        m_EnemyAnimator.SetBool("IsAttack", false);
    //    }
    //    if(GameManager.instance.m_IsPlayerDeath)
    //    {
    //        m_EnemyAnimator.SetBool("IsDected", false);
    //        m_EnemyAnimator.SetBool("IsAttack", false);
    //    }
    //    OnIsDetectedPlayer?.Invoke(m_IsDetectedPlayer,this.gameObject);
    //    OnValueEnemyFlipPlayer?.Invoke(m_ValueEnemyFlipDirection, this.gameObject);
    //}
}
