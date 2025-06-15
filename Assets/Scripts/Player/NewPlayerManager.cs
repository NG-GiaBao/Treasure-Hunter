using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Moving,
    Jumping,
    Falling,
    Attacking,
    Dead
}
public class NewPlayerManager : BaseManager<NewPlayerManager>
{

    [Header("Reference Functions")]
    public NewPlayerMove m_NewPlayerMove;
    public NewPlayerAnimation m_NewPlayerAnimation;
    public NewPlayerJump m_NewPlayerJump;
    public NewPlayerAttack m_NewPlayerAttack;
    public NewPlayerSoundFX m_NewPlayerSoundFX;
    public BloodVfx m_BloodVFx;
    public NewPLayerDeath m_NewPLayerDeath;
    public NewPlayerHeal m_NewPlayerHeal;

    [Header("State Player")]
    public PlayerState playerState;

    [Header("Stat Player")]
    public PlayerStatSO m_PlayerStatSO;

    protected override void Awake()
    {
        base.Awake();
        m_NewPlayerMove = GetComponent<NewPlayerMove>();
        m_NewPlayerAnimation = GetComponent<NewPlayerAnimation>();
        m_NewPlayerJump = GetComponent<NewPlayerJump>();
        m_NewPlayerAttack = GetComponent<NewPlayerAttack>();
        m_NewPlayerSoundFX = GetComponent<NewPlayerSoundFX>();
        m_BloodVFx = GetComponent<BloodVfx>();
        m_NewPLayerDeath = GetComponent<NewPLayerDeath>();
        m_NewPlayerHeal = GetComponent<NewPlayerHeal>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_NewPlayerHeal.GetIsPlayerDeath())
        {
            return;
        }
        m_NewPlayerMove.PlayerMovement();
        m_NewPlayerMove.PlayerFlip();
        m_NewPlayerJump.PlayerJump();
        m_NewPlayerJump.HandleLandingSound();
    }
}




