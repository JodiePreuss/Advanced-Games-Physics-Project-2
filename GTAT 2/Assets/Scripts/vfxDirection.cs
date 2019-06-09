using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class vfxDirection : MonoBehaviour
{
    public float t;
    private Vector3 setDirection;
    private GameObject vfx;
    // Start is called before the first frame update
    void Start()
    {
        //vfx = this.gameObject;

        //var VF = GetComponent<VisualEffectAssetEditor>();

        //var Direction = VisualEffect.GetVector3("Direction");

        //Direction = QuadraticCurve();


    }


    Vector3 QuadraticCurve() {
        return new Vector3(t, t*t, 0);
    }
}
