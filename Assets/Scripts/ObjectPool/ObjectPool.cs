using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject BulletPrefab;
    public List<GameObject> BulletPool;
    public int PoolCount = 20;
    public Transform PoolTransform;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitBullets();
    }
    
    void InitBullets()
    {
        for(int i = 0; i < PoolCount; i++)
        {
            InstantiateNewBulletToPool();
        }
    }

    void InstantiateNewBulletToPool()
    {
        GameObject bullet = Instantiate(BulletPrefab, PoolTransform);
        bullet.SetActive(false);
        BulletPool.Add(bullet);
    }

    public GameObject GetBullet()
    {
        if (BulletPool.Count == 0)
            InstantiateNewBulletToPool();

        GameObject temp = BulletPool[0];
        BulletPool.RemoveAt(0);
        return temp;
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.SetParent(PoolTransform);
        BulletPool.Add(bullet);
    }
}
