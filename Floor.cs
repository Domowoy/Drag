using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{


    private float bridgeZ = 278f;
    private float stairsPos = 0f;
    private float stairZ = 100f;
    private float stairY = 1f;

    void CreateGround()
    {
        //creating deadzone
        GameObject deadzone = new GameObject("Deadzone");
        deadzone.transform.position = new Vector3(100, -50, 750);
        deadzone.transform.localScale = new Vector3(1000, 4, 3000);
        deadzone.AddComponent<DeadZone>();
        deadzone.AddComponent<BoxCollider>().isTrigger = true;

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

        //Mauer trigger und Generierung von der Mauer
        GameObject trigger = new GameObject("WallTrigger");
        trigger.transform.Translate(60, 70, 680);
        trigger.transform.eulerAngles = new Vector3(0, -22, 0);
        trigger.transform.localScale = new Vector3(1, 60, 220);
        trigger.AddComponent<WallTrigger>().firstBrickPosition = new Vector3(100, 74, 775);
        trigger.AddComponent<BoxCollider>().isTrigger = true;

        //creating stone spawners
        GameObject parent = new GameObject("StoneSpawners");
        for (int z = 405; z <= 780; z += 50)
        {
            GameObject spawner = new GameObject("StoneSpawner");
            spawner.transform.SetParent(parent.transform);
            spawner.transform.position = new Vector3(-120
                , 74.1f, z);
            spawner.AddComponent<StoneSpawner>().pos = Direction.Left;
        }
        for (int z = 430; z <= 780; z += 50)
        {
            GameObject spawner = new GameObject("StoneSpawner");
            spawner.transform.SetParent(parent.transform);
            spawner.transform.position = new Vector3(95, 74.1f, z);
            spawner.AddComponent<StoneSpawner>().pos = Direction.Right;
        }

        // Bergentrigger und Generierung
        GameObject mountainTrigger = new GameObject("mountainTrigger");
        mountainTrigger.transform.position = new Vector3(-100, 90, 860);
        mountainTrigger.transform.localScale = new Vector3(100, 60, 1);
        mountainTrigger.AddComponent<MountainsTrigger>();
        mountainTrigger.AddComponent<BoxCollider>().isTrigger = true;

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
        floor8.transform.localScale = new Vector3(30, 4, 60);
        floor8.transform.Translate(200, 70, 1340);
        floor8.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor8.AddComponent<MovingPlatforms>().turnBackOnCollisionOnly = true;
        floor8.name = "Boden8";

        GameObject floor9 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor9.transform.localScale = new Vector3(200, 4, 200);
        floor9.transform.Translate(200, 70, 1480);
        floor9.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor9.tag = "Ground";
        floor9.name = "Boden9";

        GameObject floor10 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor10.transform.localScale = new Vector3(30, 4, 80);
        floor10.transform.Translate(200, 70, 1040);
        floor10.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        floor10.AddComponent<MovingPlatforms>().turnBackOnCollisionOnly = true;
        floor10.name = "Boden10";
    }

    void CreatePlatforms()
    {
        Platform(new Vector3(-90, 70, 800));
        Platform(new Vector3(-90, 70, 830));
        Platform(new Vector3(-90, 70, 860));
        Platform(new Vector3(80, 70, 800), false);
        Platform(new Vector3(50, 70, 830), false);
        Platform(new Vector3(20, 70, 860), false);
    }

    void Platform(Vector3 pos, bool isFallingPlatform = true)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane.transform.localScale = new Vector3(20, 4, 20);
        plane.transform.Translate(pos);
        plane.GetComponent<Renderer>().material.color = new Color(13 / 255f, 101 / 255f, 16 / 255f);
        plane.AddComponent<Rigidbody>().isKinematic = true;
        if (isFallingPlatform)
            plane.AddComponent<FallingPlatforms>();
        else
            plane.AddComponent<MovingPlatforms>().turnBackOnCollisionOnly = false;

        plane.name = "plane";
    }



    void CreateStairs(Transform parent)
    {
        GameObject stairs = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stairs.transform.localScale = new Vector3(10, 2, 6);
        stairs.transform.Translate(0, stairY, stairZ);
        stairs.GetComponent<Renderer>().material.color = new Color(83 / 255f, 83 / 255f, 83 / 255f);
        stairs.GetComponent<Collider>().isTrigger = true;
        stairs.AddComponent<Stair>();
        stairs.name = "Stairs";

        stairY = stairY + 2;
        stairZ = stairZ + 5;
    }


    void CreateBridge(Transform parent)
    {
        GameObject bridge = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bridge.transform.localScale = new Vector3(20, 0.5f, 2);
        bridge.transform.Translate(0, 72, bridgeZ);
        bridge.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        bridge.GetComponent<Renderer>().material.name = "Lila";
        bridge.name = "bridge";


        bridgeZ = bridgeZ + 3;

    }

    void CreateBridgeSkeleton(Transform parent)
    {

        GameObject pLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pLeft.transform.localScale = new Vector3(0.5f, 0.5f, 110);
        pLeft.transform.Translate(-10, 82, 329);
        pLeft.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        pLeft.name = "pLeft";


        GameObject pRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pRight.transform.localScale = new Vector3(0.5f, 0.5f, 110);
        pRight.transform.Translate(10, 82, 329);
        pRight.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        pRight.name = "pRight";


        GameObject pMid = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pMid.transform.localScale = new Vector3(1.0f, 0.5f, 110);
        pMid.transform.Translate(0, 71.5f, 329);
        pMid.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        pMid.name = "pMid";


        GameObject seule1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        seule1.transform.localScale = new Vector3(2, 14, 2);
        seule1.transform.Translate(-10, 77, 274);
        seule1.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        seule1.name = "seule1";


        GameObject seule2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        seule2.transform.localScale = new Vector3(2, 14, 2);
        seule2.transform.Translate(10, 77, 274);
        seule2.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        seule2.name = "seule2";


        GameObject seule3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        seule3.transform.localScale = new Vector3(2, 14, 2);
        seule3.transform.Translate(-10, 77, 385);
        seule3.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        seule3.name = "seule3";


        GameObject seule4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        seule4.transform.localScale = new Vector3(2, 14, 2);
        seule4.transform.Translate(10, 77, 385);
        seule4.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        seule4.name = "seule4";

    }

    void createStartpoint()
    {
        GameObject start = GameObject.CreatePrimitive(PrimitiveType.Cube);
        start.transform.localScale = new Vector3(80, 1, 80);
        start.transform.Translate(0, 0, -50);
        start.GetComponent<Renderer>().material.color = new Color(115 / 255f, 115 / 255f, 115 / 255f);
        start.name = "start";
    }


    static Floor instance;

    void Start()
    {
        canSpawnTree = true;

        instance = this;

        CreateGround();

        GameObject bridgeParent = new GameObject("Bridge");
        GameObject stairsParent = new GameObject("Stairs");
        GameObject treesParent = new GameObject("Trees");
        treesParent.AddComponent<Rigidbody>().isKinematic = true;


        CreateBridgeSkeleton(bridgeParent.transform);

        for (float i = stairsPos; i < 35; i++)
        {
            CreateStairs(stairsParent.transform);
            CreateBridge(bridgeParent.transform);

        }

        createStartpoint();
        CreatePlatforms();
    }


  
    static bool canSpawnTree = true; //Jede Sekunde verteilen

    public static void SpawnTrees(Vector3 mingoPos)
    {
        if (canSpawnTree)
        {
            int i = Random.value > 0.5f ? -1 : 1;
            Vector3 pos = new Vector3(mingoPos.x + Random.Range(15, 50) * i, mingoPos.y, mingoPos.z + Random.Range(0, 50));
            SpawnTree(pos);
            instance.StartCoroutine(ReactivateTreeSpawn());
        }
    }

    static void SpawnTree(Vector3 pos)
    {
        //Falls Baum den Boden nicht berührt nicht verteilen
        bool isTouchingGround = false;
        foreach (Collider coll in Physics.OverlapBox(pos, new Vector3(.1f, 10, .1f), Quaternion.identity))
        {
            if (coll.CompareTag("Ground"))
            {
                isTouchingGround = true;
                break;
            }
        }
        if (!isTouchingGround)
            return;

        GameObject baum = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        baum.transform.localScale = new Vector3(20, 30, 20);
        baum.transform.position = new Vector3(pos.x, pos.y + 20 + Random.value * 10, pos.z);
        baum.GetComponent<Renderer>().material.color = new Color(115 / 255f, 252 / 255f, 119 / 255f);
        baum.name = "Baum";
        GameObject stamm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stamm.transform.localScale = new Vector3(2, 40, 2);
        stamm.transform.position = pos;
        stamm.GetComponent<Renderer>().material.color = new Color(100 / 255f, 51 / 255f, 9 / 255f);
        stamm.name = "Baum";
        baum.transform.parent = stamm.transform;
    }


    static IEnumerator ReactivateTreeSpawn()
    {
        canSpawnTree = false;
        yield return new WaitForSeconds(0.25f);
        canSpawnTree = true;
    }

}
