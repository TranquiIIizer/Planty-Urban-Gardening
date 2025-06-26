using System;
using System.Collections;
using UnityEngine;

public class PlantWiltController : MonoBehaviour
{
    private Material _plantMaterial;
    public float tintJumpValue;
    public float tintValue;

    private void Start()
    {
        _plantMaterial = GetComponent<Renderer>().material;
    }

    public void WiltProgressSet()
    {
        tintValue += tintJumpValue;
        
        if (tintValue >= 1)
            tintValue = 1;
        
        _plantMaterial.SetFloat("_WiltAmount", tintValue);
    }

    public void WiltReset()
    {
        tintValue = 0;
        _plantMaterial.SetFloat("_WiltAmount", 0);
    }
}
