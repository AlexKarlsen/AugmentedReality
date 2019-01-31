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
        if ((Earth.transform.position - transform.position).magnitude <= 
        (Earth.transform.lossyScale.magnitude + transform.lossyScale.magnitude))
        {
            print("AV!");
        }
    }
}
