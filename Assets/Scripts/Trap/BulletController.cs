using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int m_BulletDmg;
    [SerializeField] public float m_BulletSpeed;
    [SerializeField] private Rigidbody2D m_RigidBody2d;
    [SerializeField] private string[] m_TagCollision;

    [Header("SoundFX")]
    [SerializeField] private AudioClip m_HitPlayerAudioClip;

    private void Awake()
    {
        m_RigidBody2d = GetComponent<Rigidbody2D>();
    }
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            NewPlayerManager.Instance.m_NewPlayerAnimation.GetAnimator().SetTrigger("IsHit");
            PlaySoundFxPlayerHit();
            NewPlayerManager.Instance.m_NewPlayerHeal.PlayerHealReduction(m_BulletDmg);
            NewPlayerManager.Instance.m_NewPlayerHeal.CheckPlayerHeal();

            if(ListenerManager.HasInstance)
            {
                ListenerManager.Instance.BroadCast(ListenType.OnSendSpikeShoot,this.gameObject );
            }
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Tree") || collision.gameObject.CompareTag("Enemy"))
        {
            if (ListenerManager.HasInstance)
            {
                ListenerManager.Instance.BroadCast(ListenType.OnSendSpikeShoot, this.gameObject);
            }
        }
    }

    public void BulletVelocity(bool direction)
    {
        if (direction)
        {
            Debug.Log("Direction Right true");
            m_RigidBody2d.velocity = new Vector2(m_BulletSpeed, m_RigidBody2d.velocity.y);
        }
        else
        {
            Debug.Log("Direction Right false");
            m_RigidBody2d.velocity = new Vector2(-m_BulletSpeed, m_RigidBody2d.velocity.y);
        }
    }
    public void BulletVelocity(float scale)
    {
        m_RigidBody2d.velocity = new Vector2(-m_BulletSpeed*scale, m_RigidBody2d.velocity.y);
    }

    private void PlaySoundFxPlayerHit()
    {
        AudioManager.Instance.PlaySoundEffect(m_HitPlayerAudioClip);
    }
  
}
