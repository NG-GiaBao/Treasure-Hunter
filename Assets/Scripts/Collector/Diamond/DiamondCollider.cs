using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollider : MonoBehaviour
{
    [SerializeField] private bool m_IsTouchPlayer;
    [SerializeField] private float m_TimeDestroy;
    [SerializeField] private Collider2D m_DiamondCollider;
    [SerializeField] private DiamondAnim m_DiamondAnim;
    [SerializeField] public string DiamondType;
    [SerializeField] private AudioClip m_DiamondAudioClip;

    [SerializeField] private ParticleSystem m_CollerEffect;
    [SerializeField] private int m_Amount = 1;
    

    public static Action<string,int> OnDiamondCollected; // Event với tên kim cương


    private void Awake()
    {
        m_DiamondCollider = GetComponent<Collider2D>();
        m_DiamondAnim = GetComponent<DiamondAnim>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            m_IsTouchPlayer = true;
            m_DiamondAnim.SetChangeAnimDiamond();
            OnDiamondCollected?.Invoke(DiamondType , m_Amount);
            DiamondAudioClip();
            ActiveEffect();
            StartCoroutine(SetTimeDestroyDiamond());
        }
        
    }
    private IEnumerator SetTimeDestroyDiamond()
    {
        yield return new WaitForSeconds(m_TimeDestroy);
        this.gameObject.SetActive(false);
    }
    public bool GetIsTouchPlayer()
    {
        return m_IsTouchPlayer;
    }

    private void DiamondAudioClip()
    {
        AudioManager.Instance.PlaySoundEffect(m_DiamondAudioClip);
    }
    private void ActiveEffect()
    {
       ParticleSystem collecEffect = Instantiate(m_CollerEffect, transform.position, Quaternion.identity);
       Destroy(collecEffect,1f);

    }    
}
