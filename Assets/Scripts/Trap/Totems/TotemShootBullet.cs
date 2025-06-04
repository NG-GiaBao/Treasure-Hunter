
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemShootBullet : TrapShoot
{
    [Header("SoundFX")]
    [SerializeField] private AudioClip m_ShootTotemAudioClip;
    public override void ShootingBullet() // used animation event
    {
        if (m_BulletPrehap != null && m_SpawnPoint != null)
        {

            GameObject woodSpike = Instantiate(m_BulletPrehap, m_SpawnPoint.position, m_SpawnPoint.rotation);
            Rigidbody2D woodSpikeRb = woodSpike.GetComponent<Rigidbody2D>();
            if (woodSpikeRb != null)
            {
                //woodSpikeRb.velocity = new Vector2(-m_BulletSpeed, 0f);
            }
            Destroy(woodSpike, m_TimeDestroyBullet);
        }
    }
    public void PlaySoundFXShootTotem()
    {
        AudioManager.instance.PlaySoundEffect(m_ShootTotemAudioClip);
    }
}
