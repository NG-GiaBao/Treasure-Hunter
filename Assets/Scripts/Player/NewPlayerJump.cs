using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerJump : MonoBehaviour
{
    [SerializeField] private bool m_IsPressSpace;
    [SerializeField] private bool m_IsGrounded;
    [SerializeField] private Transform m_CheckGroundSpawn;
    [SerializeField] private float m_PlayerJumpSpeed;
    [SerializeField] private Transform m_JumpDustPos;
    [SerializeField] private Transform m_JumpFallPos;
    [SerializeField] private GameObject m_JumpDustPrehaps;
    [SerializeField] private GameObject m_JumpFallPrehaps;
    [SerializeField] private LayerMask m_LayerMask;
    [SerializeField] private float m_Radius;
    [SerializeField] private bool m_HasPlayedLandingSound = true;

    [SerializeField] private InputAction m_ButtonJump;

    private void Start()
    {
        m_ButtonJump.Enable();
        m_ButtonJump.performed += OnJumpPerformed;
        m_ButtonJump.canceled += OnJumpCanceled;
    }
    private void OnDestroy()
    {
        m_ButtonJump.performed -= OnJumpPerformed;
        m_ButtonJump.canceled -= OnJumpCanceled;
        m_ButtonJump.Disable();
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        m_IsPressSpace = true;
        NewPlayerManager.instance.m_NewPlayerAnimation.PlayerJump(m_IsPressSpace);
    }
    private void OnJumpCanceled(InputAction.CallbackContext context)
    {
        m_IsPressSpace = false;
    }
    public void PlayerJump()
    {
        Collider2D checkGroundCollider2d = Physics2D.OverlapCircle(m_CheckGroundSpawn.position, m_Radius, m_LayerMask);
        m_IsGrounded = checkGroundCollider2d != null;
        if (!m_IsGrounded)
        {
            NewPlayerManager.instance.playerState = PlayerState.Jumping;
            m_HasPlayedLandingSound = false; // [Sửa] Đặt lại cờ khi đang nhảy
            return;
        }
        else
        {
            if (m_IsPressSpace)
            {
                //PlayJumoSoundEffect();
                NewPlayerManager.instance.m_NewPlayerMove.m_PlayerRb.velocity = new Vector2(0, m_PlayerJumpSpeed);
                if (m_JumpDustPos != null && m_JumpDustPrehaps != null)
                {
                    GameObject justDumst = Instantiate(m_JumpDustPrehaps, m_JumpDustPos.position, Quaternion.identity);
                    Destroy(justDumst, 0.5f);
                }
                //StartCoroutine();
            }
            else
            {
                NewPlayerManager.instance.m_NewPlayerAnimation.PlayerJump(m_IsPressSpace);
            }
        }
    }
     public void HandleLandingSound()
    {
        // [Sửa] Logic phát âm thanh chỉ khi chạm đất lần đầu
        if (m_IsGrounded && !m_HasPlayedLandingSound)
        {
            NewPlayerManager.instance.m_NewPlayerSoundFX.PlayLandingSoundEffect();
            m_HasPlayedLandingSound = true; // Đặt cờ để ngăn phát âm thanh liên tục
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameObject justFall = Instantiate(m_JumpFallPrehaps, m_JumpFallPos.position, Quaternion.identity);
            Destroy(justFall, 0.5f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(m_CheckGroundSpawn.position, m_Radius);
    }
}
