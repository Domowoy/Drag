using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair: MonoBehaviour {

    Color initialColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        Renderer ren = GetComponent<Renderer>();
        initialColor = ren.material.color;
        ren.material.color = Color.white;
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.color = initialColor;
    }
}
