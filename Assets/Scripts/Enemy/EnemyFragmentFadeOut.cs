using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFragmentFadeOut : FragmentFadeOut
{
    [SerializeField] private EnemyDeath m_EnemyDeath;
    [SerializeField] private float m_FadeDuration = 2.0f; // Thời gian làm mờ
    [SerializeField] private SpriteRenderer m_SpriteRenderer;

    private float m_ElapsedTime = 0f; // Thời gian đã trôi qua

    private void Awake()
    {
        m_EnemyDeath = GetComponent<EnemyDeath>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ChangeAlpha();
    }

    public override void ChangeAlpha()
    {
        if (m_EnemyDeath != null && m_SpriteRenderer != null)
        {
            if (m_EnemyDeath.GetStateEnemyDead())
            {
                m_ElapsedTime += Time.deltaTime;

                if (m_ElapsedTime <= m_FadeDuration)
                {
                    float alpha = Mathf.Lerp(1f, 0f, m_ElapsedTime / m_FadeDuration); // Chuyển đổi từ 1 về 0
                    m_SpriteRenderer.color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, alpha);
                }
                else
                {
                    //Destroy(gameObject); // Xóa đối tượng khi đã mờ hoàn toàn
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
