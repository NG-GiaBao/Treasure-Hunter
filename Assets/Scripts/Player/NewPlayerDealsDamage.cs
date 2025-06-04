using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewPlayerDealsDamage : MonoBehaviour
{
    [SerializeField] private int m_PlayerDamage;
    [SerializeField] private Transform m_SpawnCollider2d;
    [SerializeField] private Transform m_SpawnCollider2dOnAir;
    [SerializeField] private float m_Radius;
    [SerializeField] private LayerMask m_LayerMask;

    public static event Action<int, GameObject> OnPlayerDamage;
    public void CreateColliderDetectEnemy()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(m_SpawnCollider2d.position, m_Radius, m_LayerMask);
        if (hitCollider != null)
        {
            Box box = hitCollider.GetComponent<Box>();
            if (box != null)
            {
                box.OpenBox();
                box.ChangeAnimationBox();
            }
            GameObject targetObject = hitCollider.gameObject;
            OnPlayerDamage?.Invoke(m_PlayerDamage, targetObject); // gửi damge và đối tượng

            NewPlayerManager.instance.m_BloodVFx.ActiveBloodVFX(m_SpawnCollider2d);
            NewPlayerManager.instance.m_NewPlayerSoundFX.ActiveSoundFxHitByPlayer();

            BossDetecPlayer bossDetecPlayer = hitCollider.GetComponent<BossDetecPlayer>();
            if (bossDetecPlayer != null)
            {
                bossDetecPlayer.FlipWhenAttacked();
            }
        }
    }
    // Hàm tấn công trên không
    public void CreateColliderDetectEnemyOnAir()
    {
        Collider2D hitColliderOnAir = Physics2D.OverlapCircle(m_SpawnCollider2dOnAir.position, m_Radius, m_LayerMask);
        if (hitColliderOnAir != null)
        {
            GameObject targetObject = hitColliderOnAir.gameObject;
            OnPlayerDamage?.Invoke(m_PlayerDamage, targetObject); // 
            NewPlayerManager.instance.m_BloodVFx.ActiveBloodVFX(m_SpawnCollider2dOnAir);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(m_SpawnCollider2d.position, m_Radius);
        Gizmos.DrawSphere(m_SpawnCollider2dOnAir.position, m_Radius);
    }
}
