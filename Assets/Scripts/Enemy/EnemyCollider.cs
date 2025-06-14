using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCollider : MonoBehaviour
{
    [Header("Check Ground")]
    [SerializeField] private Transform m_SpawnColliderGround;
    [SerializeField] private float m_Radius;
    [SerializeField] private LayerMask m_LayerMask;
    [SerializeField] private bool m_IsGround;

    [Header("Check 2 Sides")]
    [SerializeField] private Transform[] m_TranformTwoSides;

    [Header("Other Link")]
    [SerializeField] private NewPlayerHeal playerHeal;
    [SerializeField] private EnemyDamage enemyDamage;
    [SerializeField] private AudioClip m_HitPlayerAudioClip;
    public static event Action<bool,GameObject> OnIsGround;

    private void Awake()
    {
        playerHeal = GameObject.Find("Player").GetComponent<NewPlayerHeal>();
        enemyDamage = GetComponent<EnemyDamage>();
    }

    private void Update()
    {
        CheckColliderGround();
    }
    private void CheckColliderGround()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(m_SpawnColliderGround.position, m_Radius, m_LayerMask);
        if (collider2D != null)
        {
            m_IsGround = true;

        }
        else
        {
            m_IsGround = false;
        }
        OnIsGround?.Invoke(m_IsGround,this.gameObject);
    }

    private void CreatCollider2dTwoSides()
    {
        foreach (Transform t in m_TranformTwoSides)
        {
            Collider2D collider2D = Physics2D.OverlapCircle(t.transform.position, m_Radius, m_LayerMask);

            if (collider2D != null)
            {
                GameManager.Instance.ReceriverDamge(enemyDamage.GetEnemyDamage());
                BloodVFx bloodVFx = collider2D.GetComponent<BloodVFx>();
                Animator animator = collider2D.GetComponent<Animator>();
                if (animator != null && bloodVFx != null)
                {
                    //bloodVFx.ActiveBloodVFWhenHitAttack(transform);
                    PlaySoundFxPlayerHit();
                    animator.SetTrigger("IsHit");
                }
                   
            }
        }
    }
    private void PlaySoundFxPlayerHit()
    {
        AudioManager.instance.PlaySoundEffect(m_HitPlayerAudioClip);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_SpawnColliderGround.position, m_Radius);
        foreach (Transform t in m_TranformTwoSides)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.transform.position, m_Radius);
        }
    }
}
