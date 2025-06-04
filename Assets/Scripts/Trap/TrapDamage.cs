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

    public int GetTrapDamage() => m_TrapDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
            || collision.gameObject.CompareTag("Ground")
            || collision.gameObject.CompareTag("Tree"))
        {
            NewPlayerHeal playerHeal = collision.gameObject.GetComponent<NewPlayerHeal>();
            BloodVFx bloodVFx = collision.gameObject.GetComponent<BloodVFx>();
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
        AudioManager.instance.PlaySoundEffect(m_HitPlayerAudioClip);
    }

    private void CheckNameTrap()
    {
        if (this.transform.tag.Equals("AirTrap"))
        {
            gameObject.SetActive(false);
        }
    }
}
