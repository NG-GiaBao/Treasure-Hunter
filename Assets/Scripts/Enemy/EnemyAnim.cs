using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private Animator m_EnemyAnimator;
    [SerializeField] private bool m_IsGrouded;
    [SerializeField] private Transform m_SpawnCheckJump;
    [SerializeField] private LayerMask m_LayerMask;
    [SerializeField] private float m_Radius;

    private void Awake()
    {
        m_EnemyAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyJump.OnJump += SetAnimationJump;
        EnemyJump.OnJump += SetAnimationAttack;
        EnemyCollider.OnIsGround += SetAnimationAttack;
        EnemyCollider.OnIsGround += CheckEnemyIsGround;
    }
    private void OnDestroy()
    {
        EnemyJump.OnJump -= SetAnimationJump;
        EnemyJump.OnJump -= SetAnimationAttack;
        EnemyCollider.OnIsGround -= SetAnimationAttack;
        EnemyCollider.OnIsGround -= CheckEnemyIsGround;
    }
    private void SetAnimationJump(bool m_IsJump,GameObject gameObject)
    {
        if(gameObject == this.gameObject)
        {
            if (m_IsJump)
            {
                m_EnemyAnimator.SetBool("Jump", true);
            }
            else
            {
                m_EnemyAnimator.SetBool("Jump", false);
            }
        }
      
    }
    private void SetAnimationAttack(bool m_IsJump,GameObject gameObject)
    {
        if (gameObject == this.gameObject)
        {
            m_SpawnCheckJump.SetParent(null);

            Collider2D collider2D = Physics2D.OverlapCircle(m_SpawnCheckJump.position, m_Radius, m_LayerMask);

            if (!m_IsJump && collider2D != null)
            {
                m_EnemyAnimator.SetBool("IsAttack", true);
            }
        }
           
    }
    private void SetAnimationGround()
    {
        if(m_IsGrouded)
        {
            m_EnemyAnimator.SetBool("IsGround",true);
        }
        else
        {
            m_EnemyAnimator.SetBool("IsGround", false);
        }
    }
    private void CheckEnemyIsGround(bool IsGround, GameObject gameObject)
    {
        if (gameObject == this.gameObject)
        {
            m_IsGrouded = IsGround;
            SetAnimationGround();
        }
    }
    //private IEnumerator IEDelayAnimEnemyGround()
    //{
    //    yield return new WaitForSeconds(0.1f);

    //    SetAnimationGround();
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(m_SpawnCheckJump.position, m_Radius);
    }
}
