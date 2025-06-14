using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGravity : MonoBehaviour
{
    [SerializeField] private float m_PlayerDistancePointXCheck;
    [SerializeField] private float m_PlayerDistancePointYCheck;
    [SerializeField] private float m_DistanceNearPointCheck;

    [SerializeField] private Transform m_PlayerPosition;
    [SerializeField] private Transform m_TranformPointCheck;
    [SerializeField] private Rigidbody2D m_TrapRB;
    [SerializeField] private float m_TrapGravity;
    private void Awake()
    {
        m_TrapRB = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        m_TrapRB.gravityScale = 0f;
        m_PlayerPosition = NewPlayerManager.Instance.transform;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        CalculaPlayerDistancePointCheck();
    }

    private void CalculaPlayerDistancePointCheck()
    {
        m_PlayerDistancePointXCheck = m_PlayerPosition.position.x - this.m_TranformPointCheck.position.x;
        m_PlayerDistancePointYCheck = m_PlayerPosition.position.y - this.m_TranformPointCheck.position.y;
        m_DistanceNearPointCheck = Vector2.Distance(m_PlayerPosition.position, m_TranformPointCheck.position);
        if ((m_PlayerDistancePointXCheck >= -3 || m_PlayerDistancePointXCheck <= 3)
            && m_PlayerDistancePointYCheck <= 0.5f
            && m_DistanceNearPointCheck <=1)
        {
            SetGravityTrap();
        }
    }

    private void SetGravityTrap()
    {
        m_TrapRB.gravityScale = m_TrapGravity;
    }


}
