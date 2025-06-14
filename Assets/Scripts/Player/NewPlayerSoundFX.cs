using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerSoundFX : MonoBehaviour
{
    
    [Header("SoundFX")]
    [SerializeField] private AudioClip m_SoundFxAttack;
    [SerializeField] private AudioClip m_MoveAudio;
    [SerializeField] private AudioClip m_JumpAudio;
    [SerializeField] private AudioClip m_AttackFirstAudio;
    [SerializeField] private AudioClip m_AttackSecondAudio;
    [SerializeField] private AudioClip m_AttackAirAudio;
    [SerializeField] private AudioClip m_LandingAudio;

    public void ActiveSoundFxHitByPlayer()
    {
        AudioManager.Instance.PlaySoundEffect(m_SoundFxAttack);
    }
    public void PlayMoveSoundEffect()
    {
        AudioManager.Instance.PlaySoundEffect(m_MoveAudio);
    }
    public void PlayJumoSoundEffect()
    {
        AudioManager.Instance.PlaySoundEffect(m_JumpAudio);
    }
    public void PlayAttackFirstSoundEffect()
    {
        AudioManager.Instance.PlaySoundEffect(m_AttackFirstAudio);
    }
    public void PlayAttackSecondSoundEffect()
    {
        AudioManager.Instance.PlaySoundEffect(m_AttackSecondAudio);
    }
    public void PlayAttackAirSoundEffect()
    {
        AudioManager.Instance.PlaySoundEffect(m_AttackAirAudio);
    }
    public void PlayLandingSoundEffect()
    {
        AudioManager.Instance.PlaySoundEffect(m_LandingAudio);
    }
}
