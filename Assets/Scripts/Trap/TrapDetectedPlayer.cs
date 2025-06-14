using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetectedPlayer : MonoBehaviour
{
    [SerializeField] protected float m_PlayerDistance;
    [SerializeField] protected Transform m_PlayerPos;
    [SerializeField] protected float m_DistanceDetecPlayer;
    [SerializeField] protected float m_ValueFlipDirection;
    [SerializeField] protected bool m_TrapDetecPlayer;
    [SerializeField] private TrapController m_Controller;
    

    public event Action<bool> OnIsTrapDetecPlayer;
    public event Action<float> OnValueFlipDirection;

    private void Awake()
    {
        m_Controller = GetComponent<TrapController>();
    }

    private void Update()
    {
        DetectPlayers();
        DistanceFlip();
    }
    //private void Start()
    //{
    //    PlayerPosition.OnPlayerPosition += DetectPlayers;
    //    PlayerPosition.OnPlayerPosition += DistanceFlip;
    //}
    //private void OnDestroy()
    //{
    //    PlayerPosition.OnPlayerPosition -= DetectPlayers;
    //    PlayerPosition.OnPlayerPosition -= DistanceFlip;
    //}
    protected virtual void DetectPlayers()
    {
        if(NewPlayerManager.Instance.m_NewPlayerHeal.GetIsPlayerDeath()) return;
        m_PlayerDistance = Vector2.Distance(m_PlayerPos.position, transform.position);

        if (m_PlayerDistance <= m_DistanceDetecPlayer && m_PlayerDistance >= 0)
        {
            m_TrapDetecPlayer = true;
            m_Controller.m_TrapAnim.CheckDetecPlayer(m_TrapDetecPlayer);
        }
        else if (m_PlayerDistance > m_DistanceDetecPlayer)
        {
            m_TrapDetecPlayer = false;
            m_Controller.m_TrapAnim.CheckDetecPlayer(m_TrapDetecPlayer);
        }
        if (m_PlayerDistance >= -m_DistanceDetecPlayer && m_PlayerDistance <= 0)
        {
            m_TrapDetecPlayer = true;
            m_Controller.m_TrapAnim.CheckDetecPlayer(m_TrapDetecPlayer);
        }
        else if (m_PlayerDistance < -m_DistanceDetecPlayer)
        {
            m_TrapDetecPlayer = false;
            m_Controller.m_TrapAnim.CheckDetecPlayer(m_TrapDetecPlayer);
        }
        //OnIsTrapDetecPlayer?.Invoke(m_TrapDetecPlayer);
    }
    protected virtual void DistanceFlip()
    {
        m_ValueFlipDirection = m_PlayerPos.position.x - transform.position.x;
        OnValueFlipDirection?.Invoke(m_ValueFlipDirection);
    }
   
}
