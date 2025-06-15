using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrapShoot : MonoBehaviour
{
    [SerializeField] protected Transform m_SpawnPoint;
    [SerializeField] protected float m_TimeDestroyBullet;
    [SerializeField] protected float m_SpeedShoot;
    [SerializeField] protected BulletPool m_BulletPool;

    public abstract void ShootingBullet();

    public abstract void PlaySoundFXShoot();
}
