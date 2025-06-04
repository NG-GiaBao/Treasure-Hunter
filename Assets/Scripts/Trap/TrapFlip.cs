using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TrapFlip : MonoBehaviour
{
    [SerializeField] protected bool m_IsDirectionRight = false;
    [SerializeField] protected TrapController m_Controller;


    private void Start()
    {
        m_Controller.m_TrapDetectedPlayer.OnValueFlipDirection += Flip;
    }
    private void OnDestroy()
    {
        m_Controller.m_TrapDetectedPlayer.OnValueFlipDirection -= Flip;
    }
    private void Awake()
    {
        m_Controller = GetComponent<TrapController>();
    }
    public void Flip(float valueFlip)
    {
        if (valueFlip < 0)
        {
            this.transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            m_IsDirectionRight = false;
        }
        else if (valueFlip > 0)
        {
            this.transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            m_IsDirectionRight = true;
        }
    }
    public bool GetDirectionRight()
    {
        return m_IsDirectionRight;
    }
}
