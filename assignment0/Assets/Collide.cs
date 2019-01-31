using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    public GameObject Earth;
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        Earth = GameObject.Find("Earth");
        part = GetComponent<ParticleSystem>();
        part.Stop();
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
            Rigidbody rb = GetComponent<Rigidbody>();
            //rb.AddExplosionForce(3, rb.position, 3);
            part.Play();
        }
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;
        print(other.name);
        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }
    }
}
