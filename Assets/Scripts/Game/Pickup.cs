using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float pickupAmount;
    public Material mat;
    private float colorValue;
    private bool switch_ColorValue;

    void Start()
    {
        //mat = this.gameObject.GetComponent<Material>();
    }

    void Update()
    {
        mat.color = new Color(0,colorValue,0);

        if (colorValue <= 0){switch_ColorValue = true;}
        if (colorValue >= 1){switch_ColorValue = false;}
        if (switch_ColorValue){colorValue += 1f * Time.deltaTime;}
        else{colorValue -= 1f * Time.deltaTime;}
    }
}
