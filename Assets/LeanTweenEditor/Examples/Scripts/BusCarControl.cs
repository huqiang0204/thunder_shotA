using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusCarControl : MonoBehaviour
{

    private LTBezierPath roadPath;

    public enum BusCarState
    {
        dead, running, stopping, hit
    }

    private int state = 1;
    private float carSpeed = 1.0f;
    private float carTopSpeed;
    private int charId;
    private static int carCounter;
    private float ptIter;
    private MeshFilter meshFilter;

    public void init(float startPt, LTBezierPath roadPath, BusCarFleet carFleet )
    {
        this.roadPath = roadPath;
        ptIter = startPt;

        carTopSpeed = 1000f / roadPath.length * 0.009f;

        gameObject.name = "vehicle" + carCounter;
        charId = carCounter;
        carCounter++;
    }

    private float lastIter;
    public bool wasUpdated = false;

    void Update(){
        wasUpdated = false;
        if (state == (int)BusCarState.running /*&& renderer.isVisible*/)
        {
            // print("Time.frameCount%10:"+(Time.frameCount%10)+" charId%10:"+(charId%10));
            if (GetComponent<Renderer>().isVisible) {
                wasUpdated = true;
                roadPath.place(transform, ptIter, Vector3.up);
            } else {
                transform.position = roadPath.point(ptIter);
            }

            if (carSpeed < 1.0f)
                carSpeed += Time.deltaTime / 5.0f;
            ptIter += Time.deltaTime * carTopSpeed * carSpeed;
            if (ptIter > 1.0f)
                ptIter = 0.0f;
        }

        if (state > 0 && Time.frameCount % 10 == charId % 10)
        {
            RaycastHit hitR;
            Vector3 fwd = transform.TransformDirection(Vector3.forward + Vector3.up * 0.007f);
            if (Physics.Raycast(transform.position, fwd, out hitR, 10.0f))
            {
                // if(gameObject.name.IndexOf("127"))
                //  print("name:"+hitR.transform.gameObject.name + " bus?:"+(hitR.transform.gameObject.name.IndexOf("Player")>=0) + " car?:"+(hitR.transform.gameObject.name.IndexOf("vehicle")>=0) + " state:"+state);
                if (hitR.transform.gameObject.tag.IndexOf("Player") >= 0 || hitR.transform.gameObject.name.IndexOf("vehicle") >= 0)
                {
                    state = (int)BusCarState.stopping;
                    carSpeed = 0.0f;
                }
            }
            else
            {
                state = (int)BusCarState.running;
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + Vector3.up * 0.007f) * 10.0f, Color.red);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision.name:" + collision.gameObject.name);
        // if(state && collision.gameObject.name.IndexOf("Bus")>=0){
        //  // Crashed
        //  crash();

        //  rigidbody.isKinematic = false;
        //  rigidbody.useGravity = true;
        // }
    }

    void crash()
    {
        state = (int)BusCarState.dead;
    }
}
