using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField] private int m_TrapDamage;
    [SerializeField] private AudioClip m_HitPlayerAudioClip;
    [SerializeField] private Rigidbody2D m_playerRb;
    [SerializeField] private Vector2 m_Force = new(2f, 2f);

    private void Awake()
    {
        m_playerRb = GetComponent<Rigidbody2D>();
    }
    public int GetTrapDamage() => m_TrapDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
            || collision.gameObject.CompareTag("Ground")
            || collision.gameObject.CompareTag("Tree"))
        {
            NewPlayerHeal playerHeal = collision.gameObject.GetComponent<NewPlayerHeal>();
            BloodVfx bloodVFx = collision.gameObject.GetComponent<BloodVfx>();
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (playerHeal != null && bloodVFx != null && animator != null)
            {
                //GameManager.instance.ReceriverDamge(m_TrapDamage);
                //bloodVFx.ActiveBloodVFWhenHitAttack();
                animator.SetTrigger("IsHit");
                m_playerRb.velocity = m_Force;
                PlaySoundFxPlayerHit();
            }
            CheckNameTrap();
        }
    }
    private void PlaySoundFxPlayerHit()
    {
        AudioManager.Instance.PlaySoundEffect(m_HitPlayerAudioClip);        
    }

    private void CheckNameTrap()
    {
        if (this.transform.tag.Equals("AirTrap"))
        {
            gameObject.SetActive(false);
        }
    }
}
