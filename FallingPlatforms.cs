using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms: MonoBehaviour {

    Rigidbody rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    bool triggered = false; //bewegende Platform darf nur einmal schütteln


    //wenn der Drache auf der Platform ist, die Platformm schüttelt und fällt
    private void OnCollisionEnter(Collision collision)
    {
        if (triggered)
            return;
        triggered = true;
        StartCoroutine(Shake());
        StartCoroutine(Fall());
    }

    IEnumerator Shake()
    {
        bool b = false;
        while (true)
        {
            if (b)
                transform.position += new Vector3(1, 0, 0);
            else
                transform.position -= new Vector3(1, 0, 0);

            b = !b;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(1);
        StopAllCoroutines();
        rb.isKinematic = false;
    }
}
