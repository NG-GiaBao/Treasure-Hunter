using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShoot : BaseTrapShoot
{
    [SerializeField] private TrapController trapController;
    private void Awake()
    {
        m_BulletPool = GetComponent<BulletPool>();
        trapController=GetComponent<TrapController>();
    }
    
    public override void ShootingBullet()
    {
        if (m_SpawnPoint != null)
        {
            GameObject bullet = m_BulletPool.GetBullet();
            bullet.transform.SetParent(null, true);
            bullet.transform.position = m_SpawnPoint.position;

            if (bullet != null)
            {
                if (bullet.TryGetComponent<BulletController>(out var bulletController))
                {
                    bulletController.BulletVelocity(trapController.m_TrapFlip.GetDirectionRight());
                    StartCoroutine(TimeReturnPool(bullet));
                }
            }
        }
    }
    

    public override void PlaySoundFXShoot()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE("TrapAttack");
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
