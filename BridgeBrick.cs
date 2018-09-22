using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBrick: MonoBehaviour {

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }

}
