using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator m_PlayerAnimator;
    private void Awake()
    {
        m_PlayerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        NewPlayerManager.instance.m_NewPlayerAttack.OnArrayStringAttackAnimation += PlayAttackAnimation;
        NewPlayerManager.instance.m_NewPlayerMove.OnIsMoving += PlayerIdle;
    }
    private void OnDestroy()
    {
        NewPlayerManager.instance.m_NewPlayerMove.OnIsMoving -= PlayerIdle;
        NewPlayerManager.instance.m_NewPlayerAttack.OnArrayStringAttackAnimation -= PlayAttackAnimation;
    }

    public void PlayerIdle(bool IsMoving)
    {
        if (IsMoving)
        {
            m_PlayerAnimator.SetBool("IsRun", true);
        }
        else
        {
            m_PlayerAnimator.SetBool("IsRun", false);
        }
    }
    public void PlayerJump(bool IsPressSpace)
    {
        if (IsPressSpace)
        {
            m_PlayerAnimator.SetBool("isJump", true);
        }
        else
        {
            m_PlayerAnimator.SetBool("isJump", false);
        }
    }
    public void PlayAttackAnimation(string[] AttackAnimation, int CurrentAttackIndex)
    {
        if (AttackAnimation.Length == 0) return;

        foreach (string animationName in AttackAnimation)
        {
            m_PlayerAnimator.SetBool(animationName, false);
        }

        m_PlayerAnimator.SetBool(AttackAnimation[CurrentAttackIndex], true);
    }
    public void PlayAirAnimation()
    {
        m_PlayerAnimator.SetTrigger("AirAtack");
    }
    public Animator GetAnimator()
    {
        return m_PlayerAnimator;
    }
}
