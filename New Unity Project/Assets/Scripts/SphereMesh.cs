using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SphereMesh : MonoBehaviour
{

    private Mesh mesh;
    private Vector3[] vertices;

    public int horizontalLines, verticalLines;
    public int radius;
    private int[] triangles;


    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();

    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void CreateShape()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();

        vertices = new Vector3[(horizontalLines+1) * (verticalLines+1)];
        int index = 0;
        for (int u = 0; u < horizontalLines; u++)
        {
            for (int v = 0; v < verticalLines; v++)
            {
                float x = Mathf.Sin(Mathf.PI * u / horizontalLines) * Mathf.Cos(2 * Mathf.PI * v / verticalLines);
                float y = Mathf.Sin(Mathf.PI * u / horizontalLines) * Mathf.Sin(2 * Mathf.PI * v / verticalLines);
                float z = Mathf.Cos(Mathf.PI * u / horizontalLines);
                vertices[index] = new Vector3(x, y, z);
                index++;
            }
        }

        triangles = new int[6 * (horizontalLines+1) * (verticalLines+1)];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < verticalLines; z++) {
            for (int x = 0; x < horizontalLines; x++) {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + horizontalLines + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + horizontalLines + 1;
                triangles[tris + 5] = vert + horizontalLines + 2;
                vert++;
                tris += 6;
            }

        }
       
    }


    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(transform.TransformPoint(vertices[i]), 0.01f);
        }
    }
}
