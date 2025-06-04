using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int m_BulletDmg;
    [SerializeField] public float m_BulletSpeed;
    [SerializeField] private Rigidbody2D m_RigidBody2d;
    [SerializeField] private TrapController m_TrapController;
    [SerializeField] private string[] m_TagCollision;

    [Header("SoundFX")]
    [SerializeField] private AudioClip m_HitPlayerAudioClip;

    private void Awake()
    {
        m_RigidBody2d = GetComponent<Rigidbody2D>();
        m_TrapController = GetComponent<TrapController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            NewPlayerManager.instance.m_NewPlayerAnimation.GetAnimator().SetTrigger("IsHit");
            PlaySoundFxPlayerHit();
            NewPlayerManager.instance.m_NewPlayerHeal.PlayerHealReduction(m_BulletDmg);
            NewPlayerManager.instance.m_NewPlayerHeal.CheckPlayerHeal();

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Tree") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    public void BulletVelocity()
    {
        if (m_TrapController.m_TrapFlip.GetDirectionRight())
        {
            m_RigidBody2d.velocity = new Vector2(m_BulletSpeed, m_RigidBody2d.velocity.y);
        }
        else
        {
            m_RigidBody2d.velocity = new Vector2(-m_BulletSpeed, m_RigidBody2d.velocity.y);
        }
    }

    private void PlaySoundFxPlayerHit()
    {
        AudioManager.instance.PlaySoundEffect(m_HitPlayerAudioClip);
    }
}
