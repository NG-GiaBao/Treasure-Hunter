using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject m_BulletPrefabs;
    [SerializeField] private int m_PoolSize;
    [SerializeField] private Queue<GameObject> pool = new();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            GameObject bullet = Instantiate(m_BulletPrefabs);
            bullet.transform.parent = transform;
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetBullet()
    {
        GameObject bullet = pool.Dequeue();
        if (pool.Count > 0)
        {
            bullet.SetActive (true);
        }
        return bullet;
    }

    public void ReturnPool(GameObject bullet)
    {
        bullet.SetActive(false );
        pool.Enqueue(bullet);
    }
}
