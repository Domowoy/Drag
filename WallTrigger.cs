using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger: MonoBehaviour {

    //size of the brick
    float x = 4;
    float y = 4;
    float z = 10;

    //size of the wall (bricks count)
    int height = 8;
    int width = 20;


    public Vector3 firstBrickPosition;
    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            StartCoroutine(CreateWall());
            triggered = true;
        }
    }

    IEnumerator CreateWall()
    {
        GameObject parent = new GameObject("Wall");
        parent.AddComponent<Rigidbody>().isKinematic = true;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                brick.transform.localScale = new Vector3(x, y, z);
                brick.transform.position = firstBrickPosition + new Vector3(0, i * y, j * z * -1);
                brick.GetComponent<Renderer>().material.color = Color.HSVToRGB(0, 0, Mathf.Clamp(Random.value, 0.3f, 0.7f));
                brick.transform.SetParent(parent.transform);
                yield return null;
            }
        }
        Destroy(gameObject);

    }
}
