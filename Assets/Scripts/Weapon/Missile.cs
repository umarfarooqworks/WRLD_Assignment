using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target;

    bool used = false;

    [SerializeField]
    int damage;

    [SerializeField]
    float sleftDestroyTime;

    [SerializeField]
    float missileSpeed = 4f;
    float instantiatedAt;
    float hitDistance = 1f;

    private void OnEnable()
    {
        StartCoroutine(nameof(softDestroyAfter));
    }

    public void Init(Transform _target)
    {
        used = false;
        target = _target;
    }

    private void Update()
    {
        if (used)
            return;

        if (target == null)
            return;

        MoveToTarget();
        CheckIfReacedDestination();
    }

    private void MoveToTarget()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * missileSpeed);
    }
    void CheckIfReacedDestination()
    {
        if (Utilities.Distance(transform, target) < hitDistance)
        {
            StopCoroutine("softDestroyAfter");
            target.GetComponent<IGetHit>().GetHit(damage);
            ObjectPool.Instance.ReturnBulletToPool(gameObject);
//            Destroy(gameObject);
        }
    }

    IEnumerator softDestroyAfter()
    {
        yield return Utilities.GetWaitForSeconds(sleftDestroyTime);
        ObjectPool.Instance.ReturnBulletToPool(gameObject);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
