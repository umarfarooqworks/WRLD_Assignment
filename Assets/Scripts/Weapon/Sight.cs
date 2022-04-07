using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    EnemySpawner EnemySpawner;
    [SerializeField]
    int MinDistance = 100;
    [SerializeField]
    int MinAngle = 30;
    [SerializeField]
    float SearchFrequency = 0.1f;

    public event Action<Transform> TargetInSight = delegate { };
    public event Action<Transform> TargetyOutOfSight = delegate { };

    private void Start()
    {
        EnemySpawner = GameManager.Instance.EnemySpawner;
        StartCoroutine(nameof(StartSearchingForEnemies));
    }
    
    IEnumerator StartSearchingForEnemies()
    {
        while (true)
        {
            foreach (Transform enemy in EnemySpawner.SpawnedEnemies)
            {
                if (isObjectInFront(enemy) && Utilities.Distance(transform, enemy) < MinDistance && enemy.gameObject.activeInHierarchy)
                {
                    Debug.Log("Object is in front and in distance");
                    TargetInSight.Invoke(enemy);
                }
                else
                {
                    TargetyOutOfSight.Invoke(enemy);
                }
            }
            yield return Utilities.GetWaitForSeconds(SearchFrequency);
        }
    }

    public bool isObjectInFront(Transform target)
    {
        //var heading = target.position - transform.position;
        //var val = Vector3.Dot(heading, transform.forward);

        //Debug.Log("dotProduct: " + val);

        //if (val > 0.6)
        //    return true;
        //return false;

        float angel = Vector3.Angle(transform.forward, target.position - transform.position);
        if (Mathf.Abs(angel) < MinAngle)
        {
            return true;
        }
        else return false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
