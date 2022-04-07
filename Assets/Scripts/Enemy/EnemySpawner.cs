using Assets.Wrld.Scripts.Maths;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrld;
using Wrld.Space;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab = null;

    private LatLong cameraLocation = LatLong.FromDegrees(37.795641, -122.404173);
    private LatLong boxLocation1 = LatLong.FromDegrees(37.795159, -122.404336);
    private LatLong boxLocation2 = LatLong.FromDegrees(37.795173, -122.404229);

    public List<Transform> SpawnedEnemies;
    private void OnEnable()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        Api.Instance.CameraApi.MoveTo(cameraLocation, distanceFromInterest: 400, headingDegrees: 0, tiltDegrees: 45);

//        while (true)
        {
            yield return new WaitForSeconds(7.0f);

            SpawnEnemy(boxLocation1);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy(boxLocation1);
        }
    }


    void SpawnEnemy(LatLong latLong)
    {
        var ray = Api.Instance.SpacesApi.LatLongToVerticallyDownRay(latLong);
        LatLongAltitude buildingIntersectionPoint;
        bool didIntersectBuilding = Api.Instance.BuildingsApi.TryFindIntersectionWithBuilding(ray, out buildingIntersectionPoint);

        Debug.Log("didIntersectBuilding: " + didIntersectBuilding);

        if (didIntersectBuilding)
        {
            var boxAnchor = Instantiate(boxPrefab) as GameObject;
            SpawnedEnemies.Add(boxAnchor.transform);

            boxAnchor.GetComponent<GeographicTransform>().SetPosition(buildingIntersectionPoint.GetLatLong());

            //            var box = boxAnchor.transform.GetChild(0);
            boxAnchor.transform.localPosition = Vector3.up * (float)buildingIntersectionPoint.GetAltitude();
            //            Destroy(boxAnchor, 2.0f);
        }

    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
