using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms: MonoBehaviour {

    Rigidbody rb;
    public bool turnBack;
    float speed = 0.25f;

    float maxZ = 900;
    float minZ = 800;


    public bool turnBackOnCollisionOnly;     // aus Floor.cs, definiert die Bewegung und die Logik, "wann zurück"


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {

        if (!turnBackOnCollisionOnly && (rb.position.z > maxZ || rb.position.z < minZ))
            turnBack = !turnBack;

        if (turnBack)
            rb.MovePosition(rb.position + new Vector3(0, 0, -speed));
        else
            rb.MovePosition(rb.position + new Vector3(0, 0, speed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (turnBackOnCollisionOnly && !collision.gameObject.CompareTag("Player"))
           turnBack = !turnBack;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (turnBack)
                collision.rigidbody.MovePosition(collision.rigidbody.position + new Vector3(0, 0, -speed));
            else
                collision.rigidbody.MovePosition(collision.rigidbody.position + new Vector3(0, 0, speed));

        }
    }
}
