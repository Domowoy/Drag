using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Right, Left };

public class Stone: MonoBehaviour {

    float speed = 0.5f;
    Rigidbody rb;
    public Direction dir;

    private void Start()
    {
        StartCoroutine(DestroyTimer());
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(dir == Direction.Left)
            rb.MovePosition(rb.position + new Vector3(-speed, 0, 0));
        else
            rb.MovePosition(rb.position + new Vector3(speed, 0, 0));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Mingo.Restart();
        else if (!other.isTrigger)
            Destroy(gameObject);
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
