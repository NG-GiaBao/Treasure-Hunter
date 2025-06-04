using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnim : MonoBehaviour
{
    [SerializeField] protected Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void CheckDetecPlayer(bool IsDetecPlayer)
    {
        if (IsDetecPlayer)
        {
            m_Animator.SetBool("IsDected", true);
            m_Animator.SetBool("IsFire", true);
        }
        else
        {
            m_Animator.SetBool("IsDected", false);
            m_Animator.SetBool("IsFire", false);
        }
    }
}
