using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMove : MonoBehaviour
{
    [SerializeField] private Vector2 m_PlayerMove;
    [SerializeField] private float m_PlayerSpeed;
    public Rigidbody2D m_PlayerRb;
    [SerializeField] private bool m_IsMoving;
    [SerializeField] private float m_GravityDefault;

    public event Action<bool> OnIsMoving;


    private void Awake()
    {
        m_PlayerRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        m_GravityDefault = m_PlayerRb.gravityScale;
    }
    private void OnMove(InputValue value)
    {
        m_PlayerMove = value.Get<Vector2>();
    }

    public void PlayerMovement()
    {
        Vector2 playerInput = new Vector2(m_PlayerMove.x * m_PlayerSpeed, m_PlayerRb.velocity.y);
        m_PlayerRb.velocity = playerInput; // Di chuy?n theo h??ng input
    }
    public void PlayerFlip()
    {
        m_IsMoving = Mathf.Abs(m_PlayerMove.x) > Mathf.Epsilon;
        if (m_IsMoving)
        {
            NewPlayerManager.Instance.playerState = PlayerState.Moving;
            this.transform.localScale = new Vector2(x: Mathf.Sign(m_PlayerRb.velocity.x), y: 1f);
        }else
        {
            NewPlayerManager.Instance.playerState = PlayerState.Idle;
        }
        OnIsMoving?.Invoke(m_IsMoving);
    }

    public void SetGravityOfAirAttack()
    {
        m_PlayerRb.gravityScale = 1f;
    }

    public void ResetGravityOfAirAttack()
    {
        m_PlayerRb.gravityScale = m_GravityDefault;
    }


}
