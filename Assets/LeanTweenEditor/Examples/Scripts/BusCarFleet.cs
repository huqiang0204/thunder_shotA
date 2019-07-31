using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusCarFleet : MonoBehaviour {

    public GameObject[] vehiclesPrefabs;
    public LeanTweenPath[] roadPaths;

    private int i;
    private int j;

    void Start()
    {
        float carsPerRoad = 15.0f;

        for (i = 0; i < roadPaths.Length; i++)
        {
            LTBezierPath ltPath = new LTBezierPath(roadPaths[i].vec3);
            carsPerRoad = ltPath.length * 0.015f * 1.5f;

            // print("len:"+ltPath.length+" carsPerRoad:"+carsPerRoad+" isRound:"+isRound);
            if (roadPaths[i])
            {
                for (j = 0; j < carsPerRoad; j++)
                {
                    GameObject car = Instantiate(vehiclesPrefabs[Random.Range(0, vehiclesPrefabs.Length)], transform.position, transform.rotation);
                    BusCarControl control = car.AddComponent<BusCarControl>();
                    control.init(j * 1.0f / carsPerRoad + Random.Range(0.0f, 0.8f / carsPerRoad), ltPath, this);


                }
            }
        }

    }
}
