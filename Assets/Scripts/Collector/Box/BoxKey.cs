using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKey : MonoBehaviour
{
    [SerializeField] private GameObject Padlock;
    [SerializeField] private Transform m_PositionPadlock;
    [SerializeField] public GameObject m_PlayerPos;
    [SerializeField] private float m_force;

    private void Awake()
    {
        m_PlayerPos = GameObject.Find("Player");
    }
    public void ActivePadlock()
    {
        GameObject padlock = Instantiate(Padlock, m_PositionPadlock.position, Quaternion.identity);
        Rigidbody2D rigidbody2D = padlock.GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            rigidbody2D.velocity = new Vector2(m_PlayerPos.transform.localScale.x * m_force, m_PlayerPos.transform.localScale.y * m_force);
        }

    }
}
