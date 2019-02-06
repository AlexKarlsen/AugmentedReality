using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landing : MonoBehaviour
{

    GameObject SpaceShuttle;
    GameObject LandingLane;
    GameObject Quad;


    // Start is called before the first frame update
    void Start()
    {
        SpaceShuttle = GameObject.Find("SpaceShuttle");
        LandingLane = GameObject.Find("LandingLane");
        Quad = GameObject.Find("SpaceShuttleQuad");
    }

    // Update is called once per frame
    void Update()
    {
        print(SpaceShuttle.ToString());
        print(LandingLane.ToString());

        if(Vector3.Dot(SpaceShuttle.transform.position, LandingLane.transform.position).Equals(0))
        { 
        }
    }
}
