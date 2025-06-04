using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Move & Flip Enemy")]
    [SerializeField] private float m_EnemySpeed;
    [SerializeField] private float m_DefaulSpeed;
    [SerializeField] private Rigidbody2D m_EnemyRb;
    [SerializeField] private Transform m_SpawnPointLeft;
    [SerializeField] private Transform m_SpawnPointRight;
    [SerializeField] private float m_DistanceValueRight;
    [SerializeField] private float m_DistanceValueLeft;

    [SerializeField] private bool m_MovingLeft = true;

    [Header("Detec Player")]
    [SerializeField] private Transform m_PlayerPosion;
    [SerializeField] private float m_TargetDistanceDetecPlayerX;
    [SerializeField] private float m_DistancePlayerX;
    [SerializeField] private float m_DistancePlayerY;
    [SerializeField] private bool m_IsDetecPlayer;
    [SerializeField] private float m_PlayerDistanceEnemy;
    [SerializeField] private float m_DistancePointRightX;
    [SerializeField] private float m_DistancePointLeftX;

    [Header("Enemy Animator")]
    [SerializeField] private Animator m_EnemyAnimator;

    [Header("Other")]
    [SerializeField] private EnemyDeath m_EnemyDead;

    private void Awake()
    {
        m_EnemyRb = GetComponent<Rigidbody2D>();
        m_EnemyAnimator = GetComponent<Animator>();
        m_EnemyDead = GetComponent<EnemyDeath>();
    }
    private void Start()
    {
        m_DefaulSpeed = m_EnemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_EnemyDead.GetStateEnemyDead())
        {
            return;
        }
        CancelAttackPlayerPointRight();
        CancelAttackPlayerPointLeft();
        EnemyDistance();
        //EnemyChasePlayer();
        EnemyVelocityMove();

        //UpdateDirection();
    }

    private void EnemyDistance()
    {
        m_DistanceValueLeft = Vector2.Distance(m_SpawnPointLeft.position, this.transform.position);
        m_DistanceValueRight = Vector2.Distance(this.transform.position, m_SpawnPointRight.position);
        m_DistancePlayerX = m_PlayerPosion.position.x - this.transform.position.x;
        m_DistancePlayerY = m_PlayerPosion.position.y - this.transform.position.y;
        m_PlayerDistanceEnemy = Vector2.Distance(m_PlayerPosion.position, this.transform.position);

    }
    private void EnemyVelocityMove()
    {
        if (!m_IsDetecPlayer)
        {

            if (m_MovingLeft)
            {
                m_EnemyAnimator.SetTrigger("Antici");
                m_EnemyAnimator.SetBool("Run", true);
                transform.localScale = new Vector3(1f, 1f, 1f);
                m_EnemyRb.velocity = new Vector2(-m_EnemySpeed, m_EnemyRb.velocity.y);

                if (m_DistanceValueLeft <= 0.5f) m_MovingLeft = false;
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                m_EnemyRb.velocity = new Vector2(m_EnemySpeed, m_EnemyRb.velocity.y);

                if (m_DistanceValueRight <= 0.5f) m_MovingLeft = true;
            }
        }
    }

    //public virtual void EnemyChasePlayer()
    //{
    //    if (GameManager.instance.m_IsPlayerDeath)
    //    {
    //        this.enabled = false;
    //        return;
    //    }
    //    else
    //    {
    //        this.enabled = true;
    //    }

    //    if ((m_DistancePlayerX < m_TargetDistanceDetecPlayerX && m_DistancePlayerY < 0) && m_PlayerDistanceEnemy < m_TargetDistanceDetecPlayerX)
    //    {
    //        m_IsDetecPlayer = true;
    //        if (m_IsDetecPlayer)
    //        {
    //            m_EnemyAnimator.SetBool("Attack", true);
    //            m_EnemySpeed = 6;
    //            Vector2 direction = new Vector2(m_PlayerPosion.position.x - transform.position.x, 0f).normalized;
    //            m_EnemyRb.velocity = direction * m_EnemySpeed;
    //            if (direction.x == 1)
    //            {
    //                transform.localScale = new Vector3(-1f, 1f, 1f);
    //            }
    //            else if (direction.x == -1)
    //            {
    //                transform.localScale = new Vector3(1f, 1f, 1f);
    //            }

    //        }
    //    }
    //    else if (m_DistancePlayerY > 1.5)
    //    {
    //        m_IsDetecPlayer = false;
    //        m_EnemyAnimator.SetBool("Attack", false);
    //        m_EnemySpeed = m_DefaulSpeed;
    //    }
    //}

    private void CancelAttackPlayerPointRight()
    {
        m_DistancePointRightX = this.transform.position.x - m_SpawnPointRight.position.x;
        if (m_DistancePointRightX >= 0)
        {
            m_IsDetecPlayer = false;
            m_EnemyAnimator.SetBool("Attack", false);
            m_EnemySpeed = m_DefaulSpeed;
            //if(transform.localScale.x == 1f)
            //{
            //    transform.localScale = new Vector3(-1f, 1f, 1f);
            //}else if(transform.localScale.x == -1f)
            //{
            //    transform.localScale = new Vector3(1f, 1f, 1f);
            //}
        }
    }
    private void CancelAttackPlayerPointLeft()
    {
        m_DistancePointLeftX = this.transform.position.x - m_SpawnPointLeft.position.x;
        if (m_DistancePointLeftX <= 0)
        {
            m_IsDetecPlayer = false;
            m_EnemyAnimator.SetBool("Attack", false);
            m_EnemySpeed = m_DefaulSpeed;
            //if (transform.localScale.x == 1f)
            //{
            //    transform.localScale = new Vector3(-1f, 1f, 1f);
            //}
            //else if (transform.localScale.x == -1f)
            //{
            //    transform.localScale = new Vector3(1f, 1f, 1f);
            //}
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, m_TargetDistanceDetecPlayerX);
    }
}
