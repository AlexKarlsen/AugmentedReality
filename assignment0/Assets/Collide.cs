using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    GameObject Earth;
    // Start is called before the first frame update
    void Start()
    {
        Earth = GameObject.Find("Earth");
    }

    // Update is called once per frame
    void Update()
    {
        // Intersection of sphere A and B is |A.center-B-center| <= A.radius + B.radius
        // Lossyscale returns diameter... divide by 2 to get radius
        if (Mathf.Abs((Earth.transform.position - transform.position).magnitude) <= 
        (Earth.transform.lossyScale.magnitude/2.0f + transform.lossyScale.magnitude/2.0f))
        {
            print("Auch!");
        }
    }
}
