using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject m_BulletPrefabs;
    public GameObject BulletPrefabs => m_BulletPrefabs;
    [SerializeField] private Transform parentPool;
    [SerializeField] private int m_PoolSize;
    [SerializeField] private Queue<GameObject> pool = new();
    // Start is called before the first frame update
    void Start()
    {
        InitPool();
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.OnSendSpikeShoot, OnSendSpikeShoot);
        }
    }
    private void InitPool()
    {
        for (int i = 0; i < m_PoolSize; i++)
        {
            GameObject bullet = Instantiate(m_BulletPrefabs);
            bullet.transform.SetParent(parentPool);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }


    public GameObject GetBullet()
    {
        GameObject bullet = pool.Dequeue();
        if (pool.Count > 0)
        {
            bullet.SetActive(true);
        }
        return bullet;
    }

    public void ReturnPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.position = Vector3.zero; // Reset position if needed
        bullet.transform.SetParent(parentPool, true); // Reset parent to pool
        pool.Enqueue(bullet);
    }
    private void OnSendSpikeShoot(object value)
    {
        if (value is GameObject bullet)
        {
            ReturnPool(bullet);
        }
    }
}
