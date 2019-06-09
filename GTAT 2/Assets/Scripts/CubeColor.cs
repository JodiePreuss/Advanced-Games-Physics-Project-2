using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    private GameObject cube;
    public Color color;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        color.r = 1f;
        color.g = 1f;
        color.b = 1f;
        rend.material.color = color;
    }

}
