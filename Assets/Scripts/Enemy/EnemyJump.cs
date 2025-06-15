using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_EnemyRb;
    [SerializeField] private float m_EnemyJumpSpeed;
    [SerializeField] private bool m_IsJump;
    [SerializeField] private bool m_IsGrounded;
    [SerializeField] private EnemyController EnemyController;

    public static event Action<bool,GameObject> OnJump;
    private void Awake()
    {
        m_EnemyRb = GetComponent<Rigidbody2D>();
        EnemyController = GetComponent<EnemyController>();
    }
   
    void Start()
    {
        EnemyController.m_EnemyDetectedPlayer.OnIsDetectedPlayer += Jump;
        EnemyCollider.OnIsGround += CheckIsGrounded;
    }
    private void OnDestroy()
    {
        EnemyController.m_EnemyDetectedPlayer.OnIsDetectedPlayer -= Jump;
        EnemyCollider.OnIsGround -= CheckIsGrounded;
    }

    private void CheckIsGrounded(bool IsGrounded, GameObject gameObject)
    {
        if(gameObject==this.gameObject)
        {
            m_IsGrounded = IsGrounded;
        }
       
    }
    private void Jump(bool m_IsdetecPlayer,GameObject gameObject)
    {
        if(gameObject == this.gameObject)
        {
            if (m_IsdetecPlayer)
            {
                if (!m_IsGrounded)
                {
                    m_IsJump = false;
                    return;
                }
                else
                {
                    m_IsJump = true;
                    m_EnemyRb.velocity = new Vector2(m_EnemyRb.velocity.x, m_EnemyJumpSpeed);
                }
            }
            else
            {
                m_IsJump = false;
            }
            OnJump?.Invoke(m_IsJump,this.gameObject);
        }
       
    }
}
