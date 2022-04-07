using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    Health health;
    private void Reset()
    {
        health = GetComponent<Health>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health.onGetHitEvents += OnGetHit;
        health.onDeathEvents += OnDeath;
    }


    void OnGetHit()
    {

    }
    void OnDeath()
    {
        gameObject.SetActive(false);
        Invoke(nameof(ReEnable), 5f);
    }

    void ReEnable()
    {
        gameObject.SetActive(true);
        health.ResetHealth();
    }
    private void OnDestroy()
    {
        health.onGetHitEvents -= OnGetHit;
        health.onDeathEvents -= OnDeath;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, GameManager.Instance.Player.transform.position);
    }
}
