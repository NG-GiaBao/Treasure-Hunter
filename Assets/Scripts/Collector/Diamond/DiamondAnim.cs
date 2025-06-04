using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DiamondAnim : MonoBehaviour
{
    [SerializeField] private Animator m_DiamondAnimator;
    [SerializeField] private DiamondCollider m_DiamondCollider;

    private void Awake()
    {
        m_DiamondAnimator = GetComponent<Animator>();
        m_DiamondCollider = GetComponent<DiamondCollider>();
    }
    public void SetChangeAnimDiamond()
    {
        if(m_DiamondCollider.GetIsTouchPlayer())
        {
            m_DiamondAnimator.SetTrigger("Effect");
        }
    }
}
