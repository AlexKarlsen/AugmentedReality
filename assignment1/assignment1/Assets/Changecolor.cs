using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changecolor : MonoBehaviour
{
    GameObject SpaceShuttle;
    GameObject LandingLane;
    Color Red = new Color(255, 0, 0);
    Color Green = new Color(0, 255, 0);

    // Start is called before the first frame update
    void Start()
    {
        SpaceShuttle = GameObject.Find("SpaceShuttle");
        LandingLane = GameObject.Find("LandingLane");

    }

    // Update is called once per frame
    void Update()
    {
        if (LandingLane != null && SpaceShuttle != null)
        {
            Log();

            // Using 2D Vector as we are only concerned with the ground (x,y) directions
            // Right now we use a dot threshold of 0.5, maybe we should adjust.
            if (Vector2.Dot((Vector2)SpaceShuttle.transform.position, (Vector2)LandingLane.transform.position) > 0.5)
            {
                print("Landing");
                SpaceShuttle.GetComponent<Renderer>().material.color = Green;
            }
            else
            {
                SpaceShuttle.GetComponent<Renderer>().material.color = Red;
            }
        }
    }

    void Log()
    {
        print("Spaceshuttle coords.: " + SpaceShuttle.transform.position.ToString());
        print("Landing Lane coords.: " + LandingLane.transform.position.ToString());
        print("Dot Product = " + Vector3.Dot(SpaceShuttle.transform.position, LandingLane.transform.position).ToString());
    } 
}
