using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    [SerializeField] private Vector3 m_StartPos;
    [SerializeField] private Vector3 m_MoveBg;
    private float m_ReapetWidth;
    [SerializeField] private float m_BgSpeed;
    // Start is called before the first frame update
    void Start()
    {
        m_StartPos = transform.position;
        m_ReapetWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-m_MoveBg.x * m_BgSpeed * Time.deltaTime, m_MoveBg.y, m_MoveBg.z);
        if (transform.position.x < m_StartPos.x - m_ReapetWidth)
        {
            transform.position = m_StartPos;
        }
    }
}
