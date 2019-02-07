using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttleEarthPosition : MonoBehaviour
{
    GameObject Earth;
    GameObject SpaceShuttle;

    // Start is called before the first frame update
    void Start()
    {
        Earth = GameObject.Find("Earth");
        SpaceShuttle = GameObject.Find("SpaceShuttle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Earth != null && SpaceShuttle != null)
        {
            var EarthLocalPosition = Earth.transform.localToWorldMatrix;
            var SpaceShuttleLocalPosition = SpaceShuttle.transform.worldToLocalMatrix;
            print("Earth local position: " + EarthLocalPosition);
            print("SpaceShuttle local position: " + SpaceShuttleLocalPosition);
        }
    }
}
