using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRigibody2d : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_TrapRb;
    // Start is called before the first frame update
    private void Awake()
    {
        m_TrapRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRigibody2d();
    }
    private void UpdateRigibody2d()
    {
        m_TrapRb.velocity = new Vector2(m_TrapRb.velocity.x, 0f);
    }
}
