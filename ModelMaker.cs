using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ModelMaker {

       // Erzeugung von Bergen
    public static Mesh Pyramid(float width, float height)
    {
        float halfWidth = width / 2;

        Vector3[] verticesArray = new Vector3[5];
        verticesArray[0] = new Vector3(-halfWidth, 0, -halfWidth);
        verticesArray[1] = new Vector3(-halfWidth, 0, halfWidth);
        verticesArray[2] = new Vector3(halfWidth, 0, halfWidth);
        verticesArray[3] = new Vector3(halfWidth, 0, -halfWidth);
        verticesArray[4] = new Vector3(0, height, 0);

        Mesh mesh = new Mesh()
        {
            vertices = verticesArray,
            triangles = new int[]
            {
                0, 1, 4,
                1, 2, 4,
                2, 3, 4,
                3, 0, 4
            }
        };
        mesh.RecalculateNormals();
        return mesh;

    }
}
