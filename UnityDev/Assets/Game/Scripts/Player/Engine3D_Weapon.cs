using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine3D_Weapon : MonoBehaviour 
{
    [SerializeField]private float range;
	void Start () 
    {
		
	}
	
	void Update () 
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                Debug.Log(hit.transform.gameObject.name);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                Debug.Log("Did not Hit");
            }
        }
	}
}
