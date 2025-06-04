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
        AudioManager.instance.PlaySoundEffect(m_SoundFxAttack);
    }
    public void PlayMoveSoundEffect()
    {
        AudioManager.instance.PlaySoundEffect(m_MoveAudio);
    }
    public void PlayJumoSoundEffect()
    {
        AudioManager.instance.PlaySoundEffect(m_JumpAudio);
    }
    public void PlayAttackFirstSoundEffect()
    {
        AudioManager.instance.PlaySoundEffect(m_AttackFirstAudio);
    }
    public void PlayAttackSecondSoundEffect()
    {
        AudioManager.instance.PlaySoundEffect(m_AttackSecondAudio);
    }
    public void PlayAttackAirSoundEffect()
    {
        AudioManager.instance.PlaySoundEffect(m_AttackAirAudio);
    }
    public void PlayLandingSoundEffect()
    {
        AudioManager.instance.PlaySoundEffect(m_LandingAudio);
    }
}
