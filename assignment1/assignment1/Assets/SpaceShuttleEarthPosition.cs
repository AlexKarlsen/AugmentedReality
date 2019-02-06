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
        var SpaceShuttleLocalPosition = SpaceShuttle.transform.localPosition;
        print("SpaceShuttle local position: " + SpaceShuttleLocalPosition);
    }
}
