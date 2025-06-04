using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShoot : MonoBehaviour
{
    [SerializeField] public GameObject m_BulletPrehap;
    
    [SerializeField] public Transform m_SpawnPoint;
    [SerializeField] public float m_TimeDestroyBullet;
    [SerializeField] private BulletPool m_BulletPool;

    [Header("SoundFX")]
    [SerializeField] private AudioClip m_ShootAudioClip;

    private void Awake()
    {
        m_BulletPool = GetComponent<BulletPool>();
    }
    public virtual void ShootingBullet()
    {
        if (m_BulletPrehap != null && m_SpawnPoint != null)
        {

            GameObject pearl = m_BulletPool.GetBullet();
            Destroy(pearl, m_TimeDestroyBullet);
        }
    }
    public void PlaySoundFXShootPearl()
    {
        AudioManager.instance.PlaySoundEffect(m_ShootAudioClip);
    }
}
