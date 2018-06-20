using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public PostProcessingProfile test;

	void Update ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            float dist = Vector3.Distance(hit.point, transform.position);
            var amount = test.depthOfField.settings;
            amount.focusDistance = dist;
            test.depthOfField.settings = amount;
        }
    }
}


//[HelpURL("www.google.nl")]
//[DisallowMultipleComponent]
//[TextArea]