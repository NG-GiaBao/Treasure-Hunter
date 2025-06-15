
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemShootBullet : BaseTrapShoot
{
    private void Awake()
    {
        m_BulletPool = GetComponent<BulletPool>();
        
    }
    public override void PlaySoundFXShoot()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE("TrapAttack");
        }
    }

    public override void ShootingBullet()
    {
        if (m_SpawnPoint != null)
        {
            if(m_BulletPool!= null)
            {
                GameObject bullet = m_BulletPool.GetBullet();
                bullet.transform.SetParent(null, true);
                bullet.transform.position = m_SpawnPoint.position;
                bullet.transform.localScale = transform.localScale;

                if (bullet != null)
                {
                    if (bullet.TryGetComponent<BulletController>(out var bulletController))
                    {
                        
                        bulletController.BulletVelocity(transform.localScale.x);
                        StartCoroutine(TimeReturnPool(bullet));
                    }
                }
            }
        }
    }
    IEnumerator TimeReturnPool(GameObject bullet)
    {
        yield return new WaitForSeconds(m_TimeDestroyBullet);
        if (m_BulletPool != null)
        {
            m_BulletPool.ReturnPool(bullet);
        }
    }
}
