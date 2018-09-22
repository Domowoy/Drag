using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger: MonoBehaviour {

    // wenn Mingo trigger betretet, die letzten 3 Btäter werden zerstört, anderen sich Childs!
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other", other);

        int count = transform.parent.childCount;
        Destroy(transform.parent.GetChild(count - 3).gameObject);
        Destroy(transform.parent.GetChild(count - 4).gameObject);
        Destroy(transform.parent.GetChild(count - 5).gameObject);
        Destroy(transform.parent.GetChild(count - 6).gameObject);
        Destroy(gameObject);
    }

}
