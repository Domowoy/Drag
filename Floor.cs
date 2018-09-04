using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{


    void CreateGround()
    {
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.transform.localScale = new Vector3(200, 4, 200);
        floor.transform.Translate(0, -2, 0);
        floor.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor.tag = "Ground";
        floor.name = "Boden";

        GameObject floor1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor1.transform.localScale = new Vector3(200, 4, 200);
        floor1.transform.Translate(0, 33, 184);
        floor1.transform.Rotate(-22, 0, 0);
        floor1.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor1.tag = "Ground";
        floor1.name = "Boden1";

        GameObject floor2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor2.transform.localScale = new Vector3(200, 4, 200);
        floor2.transform.Translate(0, 70, 480);
        floor2.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor2.tag = "Ground";
        floor2.name = "Boden2";

        GameObject floor3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor3.transform.localScale = new Vector3(200, 4, 200);
        floor3.transform.Translate(0, 70, 680);
        floor3.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor3.tag = "Ground";
        floor3.name = "Boden3";

        GameObject floor4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor4.transform.localScale = new Vector3(200, 4, 200);
        floor4.transform.Translate(200, 70, 680);
        floor4.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor4.tag = "Ground";
        floor4.name = "Boden4";

        GameObject floor5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor5.transform.localScale = new Vector3(200, 4, 200);
        floor5.transform.Translate(200, 70, 880);
        floor5.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor5.tag = "Ground";
        floor5.name = "Boden5";

        GameObject floor6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor6.transform.localScale = new Vector3(200, 4, 200);
        floor6.transform.Translate(-100, 70, 980);
        floor6.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor6.tag = "Ground";
        floor6.name = "Boden6";

        GameObject floor7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor7.transform.localScale = new Vector3(200, 4, 200);
        floor7.transform.Translate(190, 70, 1195);
        floor7.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        floor7.tag = "Ice";
        floor7.name = "Boden7 ice";

        GameObject floor8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor8.transform.localScale = new Vector3(30, 4, 30);
        floor8.transform.Translate(200, 70, 1361);
        floor8.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor8.name = "Boden8";

        GameObject floor9 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor9.transform.localScale = new Vector3(200, 4, 200);
        floor9.transform.Translate(200, 70, 1480);
        floor9.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor9.tag = "Ground";
        floor9.name = "Boden9";

        GameObject floor10 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor10.transform.localScale = new Vector3(30, 4, 30);
        floor10.transform.Translate(200, 70, 1070);
        floor10.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor10.name = "Boden10";
    }

    void CreatePlatforms()
    {
        Platform(new Vector3(-90, 70, 800));
        Platform(new Vector3(-90, 70, 830));
        Platform(new Vector3(-90, 70, 860));
        Platform(new Vector3(80, 70, 800));
        Platform(new Vector3(50, 70, 830));
        Platform(new Vector3(20, 70, 860));
    }

    void Platform(Vector3 pos)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane.transform.localScale = new Vector3(20, 4, 20);
        plane.transform.Translate(pos);
        plane.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
    }


    void Start()
    {
        CreateGround();
        CreatePlatforms();
    }
}
