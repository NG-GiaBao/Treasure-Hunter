using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerAttack : MonoBehaviour
{
    [Header("Button Attack")]
    [SerializeField] private InputAction m_ButtonAttack;

    [Header("Stat Data")]
    [SerializeField] private bool m_IsPressJ;

    [Header("Animation")]
    [SerializeField] private string[] m_AttackAnimations; // Tên các clip tấn công

    [SerializeField] private int m_CurrentAttackIndex = 0; // Chỉ số của animation hiện tại

    [SerializeField] private float m_TimeDelay;

    public event Action<string[], int> OnArrayStringAttackAnimation;
    void Start()
    {
        m_ButtonAttack.Enable();
        m_ButtonAttack.performed += OnAttackPerformed;
        m_ButtonAttack.canceled += OnAttackCanceled;
    }
    private void OnDestroy()
    {
        m_ButtonAttack.performed -= OnAttackPerformed;
        m_ButtonAttack.canceled -= OnAttackCanceled;
        m_ButtonAttack.Disable();
    }
    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        m_IsPressJ = true;
        if(m_IsPressJ)
        {
            NewPlayerManager.Instance.m_NewPlayerAnimation.GetAnimator().SetBool("IsPressed", true);
            SendEventArrayString();
        }
        if(NewPlayerManager.Instance.playerState == PlayerState.Jumping)
        {
            if(m_IsPressJ)
            {
                NewPlayerManager.Instance.m_NewPlayerAnimation.PlayAirAnimation();
            }
        }
        m_CurrentAttackIndex = (m_CurrentAttackIndex + 1) % m_AttackAnimations.Length;
    }
    private void OnAttackCanceled(InputAction.CallbackContext context)
    {
        StartCoroutine(DelaySetfalse());
    }

    private void SendEventArrayString()
    {
        OnArrayStringAttackAnimation?.Invoke(m_AttackAnimations, m_CurrentAttackIndex);
    }
    private IEnumerator DelaySetfalse()
    {
        yield return new WaitForSeconds(m_TimeDelay);
        m_IsPressJ = false;
        NewPlayerManager.Instance.m_NewPlayerAnimation.GetAnimator().SetBool("IsPressed", false);
    }
}
