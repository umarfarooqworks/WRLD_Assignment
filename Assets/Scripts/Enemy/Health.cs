using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IGetHit
{
    [SerializeField]
    int HealthAmount = 100;

    public event Action onGetHitEvents = delegate { };
    public event Action onDeathEvents = delegate { };

    void OnEnable()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        HealthAmount = 100;
    }

    public void GetHit(int amount)
    {
        Debug.Log("GetHit" + amount);
        HealthAmount -= amount;

        if(HealthAmount <= 0)
        {
            onDeathEvents.Invoke();
        }
        else
        {
            onGetHitEvents.Invoke();
        }
    }
}
