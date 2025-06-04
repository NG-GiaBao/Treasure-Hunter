using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCanonBall : MonoBehaviour
{
    [SerializeField] private GameObject m_BallCanonPrehaps;
    [SerializeField] private Transform m_SpawnBallCanon;
    [SerializeField] private float m_BallSpeed;
    [SerializeField] private float m_TimeBallDestroy;
    // Start is called before the first frame update


    public void FireBallCanon()
    {
        if (m_BallCanonPrehaps != null && m_SpawnBallCanon != null)
        {
            float posX = Random.Range(0, -8);
            Vector3 ballPos = new(m_SpawnBallCanon.position.x + posX, m_SpawnBallCanon.position.y, m_SpawnBallCanon.position.z);
            GameObject ballCanon = Instantiate(m_BallCanonPrehaps, ballPos, Quaternion.identity);
            Rigidbody2D ballRb = ballCanon.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                ballRb.velocity = new Vector2(0, -m_BallSpeed);
            }
        }
    }
}
