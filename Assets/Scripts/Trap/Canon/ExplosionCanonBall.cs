using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCanonBall : MonoBehaviour
{
    [SerializeField] private Animator m_CanonBallAnimator;
    [SerializeField] private Collider2D m_BallCollider;
    // Start is called before the first frame update
    void Start()
    {
        m_CanonBallAnimator = GetComponent<Animator>();
        m_BallCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        BallCanonExplosion();
    }
    private void BallCanonExplosion()
    {
        if (m_BallCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            m_CanonBallAnimator.SetBool("IsExplosion", true);
        }
        Destroy(gameObject, 1f);
    }

}
