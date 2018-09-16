using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainsTrigger: MonoBehaviour {

	void Start () 
    {
    }

    bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            StartCoroutine(SpawnMountains());
            triggered = true;
        }
    }

    Vector3 groundPos = new Vector3(-100, 70, 980);
    List<Vector3> positions = new List<Vector3>()
    {
        new Vector3(-25,0,-75),
        new Vector3(25,0,-75),
        new Vector3(-50,0,-75),
        new Vector3(50,0,-75),
        new Vector3(-75,0,-75),
        new Vector3(75,0, -75),

        new Vector3(-25,0,-50),
        new Vector3(25,0,-50),
        new Vector3(-50,0,-50),
        new Vector3(-75,0,-50),

        new Vector3(-25,0,-25),
        new Vector3(-50,0,-25),
        new Vector3(-75,0,-25),
        new Vector3(75,0, -25),

        new Vector3(-25,0,0),
        new Vector3(25,0,0),
        new Vector3(-50,0,0),
        new Vector3(50,0,0),
        new Vector3(-75,0,0),
        new Vector3(75,0, 0),

        new Vector3(0,0,25),
        new Vector3(-25,0,25),
        new Vector3(25,0,25),
        new Vector3(-50,0,25),
        new Vector3(50,0,25),
        new Vector3(-75,0,25),
        new Vector3(75,0, 25),

        new Vector3(0,0,50),
        new Vector3(-25,0,50),
        new Vector3(25,0,50),
        new Vector3(-50,0,50),
        new Vector3(50,0,50),
        new Vector3(-75,0,50),
        new Vector3(75,0, 50),


    };

    IEnumerator SpawnMountains()
    {
        foreach(Vector3 pos in positions)
        {
            SpawnMountain(Random.Range(20, 40), Random.Range(40, 60), groundPos + pos + new Vector3(Random.Range(-5,5), 0, Random.Range(-5, 5)));
            yield return new WaitForSeconds(0.2f);
        }
    }

    void SpawnMountain(float width, float height, Vector3 pos)
    {
        GameObject mountain = new GameObject("Mountain");
        mountain.transform.position = pos;
        mountain.AddComponent<MeshFilter>().mesh = ModelMaker.Pyramid(width, height);
        mountain.AddComponent<MeshRenderer>().material = Resources.Load("Cage") as Material;
        mountain.AddComponent<MeshCollider>();
        mountain.AddComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(RaiseMountain(mountain.transform, height));
    }

    IEnumerator RaiseMountain(Transform mountain, float height)
    {
        float currentY = mountain.position.y;
        mountain.Translate(new Vector3(0, -height, 0));
        yield return null;
        for(float y = mountain.position.y;
            y < currentY;
            y += 0.5f)
        {
            mountain.position = new Vector3(mountain.position.x, y, mountain.position.z);
            yield return null;
        }
    }
}
