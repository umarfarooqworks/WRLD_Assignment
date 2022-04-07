using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{    
    public static float Distance(Transform pointA, Transform pointB)
    {
        return Vector3.Distance(pointA.position, pointB.position);
    }

    static Dictionary<float, WaitForSeconds> cachedWaitForSeconds = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWaitForSeconds(float val)
    {
        if (cachedWaitForSeconds.ContainsKey(val))
        {
            return cachedWaitForSeconds[val];
        }
        else
        {
            WaitForSeconds waitForSeconds =  new WaitForSeconds(val);
            cachedWaitForSeconds.Add(val, waitForSeconds);
            return waitForSeconds;
        }
    }

    public static Transform GetClosestTransform(Transform origin, List<Transform> transforms)
    {
        float closestDistance = Mathf.Infinity;
        int closest = 0;
        float distanceTemp;

        for (int i = 0; i < transforms.Count; i++)
        {
            distanceTemp = Utilities.Distance(origin, transforms[i]);
            if (distanceTemp < closestDistance)
            {
                closestDistance = distanceTemp;
                closest = i;
            }
        }
        return transforms[closest];
    }
}
