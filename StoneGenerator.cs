using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner: MonoBehaviour {
    
    public Direction pos;
    
    void Start () {
        
        StartCoroutine(SpawnStone());
	}

    IEnumerator SpawnStone() {
        yield return new WaitForSeconds(transform.GetSiblingIndex()); 
        while (true) {
            GameObject stone = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            stone.transform.position = transform.position;
            stone.transform.localScale = new Vector3(4, 4, 4);
            stone.GetComponent<Renderer>().material.color = Color.HSVToRGB(0, 0, Mathf.Clamp(Random.value, 0.3f, 0.7f));
            stone.AddComponent<Rigidbody>().isKinematic = true;
            stone.GetComponent<Collider>().isTrigger = true;
            stone.AddComponent<Stone>().dir = (pos == Direction.Left) ? Direction.Right : Direction.Left; 
            yield return new WaitForSeconds(4); 
        }
    }
}
