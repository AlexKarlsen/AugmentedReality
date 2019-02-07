using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changecolor : MonoBehaviour
{
    GameObject SpaceShuttle;
    GameObject LandingLane;
    Color Red = new Color(255, 0, 0);
    Color Green = new Color(0, 255, 0);
    Color Yellow = new Color(255, 255, 0); 

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
            float forwardAngle = Vector3.Angle(SpaceShuttle.transform.forward, LandingLane.transform.forward);
            float rightAngle = Vector3.Angle(SpaceShuttle.transform.right, LandingLane.transform.right);
            float upAngle = Vector3.Angle(SpaceShuttle.transform.up, LandingLane.transform.up);

            print("Angles: (" + forwardAngle + ", " + rightAngle + ", " + upAngle + ")");
            // Using 2D Vector as we are only concerned with the ground (x,y) directions
            // Right now we use a dot threshold of 0.5, maybe we should adjust.
            //if (Vector3.Dot(SpaceShuttle.transform.position, LandingLane.transform.position) > 0.95)
            //if (forwardAngle < 10.0f && rightAngle < 10.0f && upAngle < 10.0f)
            //{
            //    print("Landing");

            //    SpaceShuttle.GetComponent<Renderer>().material.color = Green;
            //}
            //else
            //{
            //    SpaceShuttle.GetComponent<Renderer>().material.color = Red;
            //}
            if (((forwardAngle + rightAngle + upAngle) / 3) < 15)
            {
                SpaceShuttle.GetComponent<Renderer>().material.color = Green;
            }
            else if (((forwardAngle + rightAngle + upAngle) / 3) < 90)
            {
                SpaceShuttle.GetComponent<Renderer>().material.color = Yellow;
            }
            else
            {
                SpaceShuttle.GetComponent<Renderer>().material.color = Red;
            }
            //print(angleSum);
            //var adjustColor = new Color(angleSum, 180 - angleSum, 0);

        }
    }

    void Log()
    {
        print("Spaceshuttle coords.: " + SpaceShuttle.transform.position.ToString());
        print("Landing Lane coords.: " + LandingLane.transform.position.ToString());
        print("Dot Product = " + Vector3.Dot(SpaceShuttle.transform.position, LandingLane.transform.position).ToString());
    } 
}
