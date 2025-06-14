using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerHeal : MonoBehaviour
{
    [SerializeField] private int m_PlayerHeal;
    [SerializeField] private bool m_IsplayerDeath;
    [SerializeField] private Transform m_SpawnPosEffectBlood;
    [SerializeField] private string[] m_TagCollision;
    public event Action<bool> OnSendStatePlayerDeath;

    private void Start()
    {
        m_PlayerHeal = NewPlayerManager.Instance.m_PlayerStatSO.PlayerHealth;
        if(ListenerManager.HasInstance)
        {
            ListenerManager.Instance.BroadCast(ListenType.OnSendPlayerHeal, m_PlayerHeal);
        }
    }
    
    public void CheckPlayerHeal()
    {
        if (m_PlayerHeal <= 0)
        {
            m_IsplayerDeath = true;
        }
        else
        {
            m_IsplayerDeath = false;
        }
        OnSendStatePlayerDeath?.Invoke(m_IsplayerDeath);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(string tag in  m_TagCollision)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Debug.Log("bbb");

                m_PlayerHeal--;
                CheckPlayerHeal();

                NewPlayerManager.Instance.m_BloodVFx.ActiveBloodVFX(m_SpawnPosEffectBlood);
                NewPlayerManager.Instance.m_NewPlayerAnimation.GetAnimator().SetTrigger("IsHit");
                NewPlayerManager.Instance.m_NewPlayerSoundFX.ActiveSoundFxHitByPlayer();
            }
        }    
    }
    public void PlayerHealReduction(int damage)
    {
        m_PlayerHeal -= damage;
    }
    public int ResetPlayerHeal()
    {
        m_PlayerHeal = NewPlayerManager.Instance.m_PlayerStatSO.PlayerHealth;
        return m_PlayerHeal;
    }
    public int UpdatePlayerHeal()
    {
        return m_PlayerHeal;
    }

    public bool GetIsPlayerDeath()
    {
        return m_IsplayerDeath;
    }
}
