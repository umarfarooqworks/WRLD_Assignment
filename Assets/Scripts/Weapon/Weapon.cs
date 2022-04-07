using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Dependencies")]
    public Sight Sight;
    public Transform MissileOrigion;
    public Transform InstantiatedMissilesParent;

    [Header("Specs")]
    [SerializeField]
    float fireFrequency = 0.5f;
    public Missile missilePrefab;
    public List<Transform> EnemiesInRange;

    Coroutine _coroutine_fireMissile;
    private void Start()
    {
        Sight.TargetInSight += AddEnemiesInSight;
        Sight.TargetyOutOfSight += RemoveEnemiesFromSight;
    }
    private void OnDisable()
    {
        Sight.TargetInSight -= AddEnemiesInSight;
        Sight.TargetyOutOfSight -= RemoveEnemiesFromSight;
    }

    void AddEnemiesInSight(Transform enemy)
    {
        if(!EnemiesInRange.Contains(enemy))
        {
            EnemiesInRange.Add(enemy);
        }

        if(_coroutine_fireMissile == null)
        {
            _coroutine_fireMissile = StartCoroutine(nameof(autoFireMissile));
        }
    }
    void RemoveEnemiesFromSight(Transform enemy)
    {
        if(EnemiesInRange.Contains(enemy))
        {
            EnemiesInRange.Remove(enemy);
        }

        if(EnemiesInRange.Count == 0)
        {
            if(_coroutine_fireMissile != null)
            {
                StopCoroutine(_coroutine_fireMissile);
                _coroutine_fireMissile = null;
            }
        }
    }

    IEnumerator autoFireMissile()
    {
        while(true)
        {
            if(EnemiesInRange.Count > 0)
            {
                GameObject bullet = ObjectPool.Instance.GetBullet();
                bullet.transform.position = MissileOrigion.position;
                bullet.transform.rotation = MissileOrigion.rotation;
                bullet.transform.SetParent(InstantiatedMissilesParent);
                bullet.GetComponent<Missile>().Init(Utilities.GetClosestTransform(transform, EnemiesInRange));
                bullet.SetActive(true);

//                Instantiate(missilePrefab, MissileOrigion.position, MissileOrigion.rotation, InstantiatedMissilesParent).Init(Utilities.GetClosestTransform(transform, EnemiesInRange));
            }
            yield return Utilities.GetWaitForSeconds(fireFrequency);
        }
    }


    Transform getClosestEnemy()
    {
        float distance = Mathf.Infinity;
        int closest = 0;
        for(int i = 0; i < EnemiesInRange.Count; i++)
        {
            if (Utilities.Distance(transform, EnemiesInRange[i]) < distance)
            {
                closest = i;
            }
        }
        return EnemiesInRange[closest];
    }
}
