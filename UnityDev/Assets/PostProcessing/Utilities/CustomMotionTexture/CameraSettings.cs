using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public PostProcessingProfile test;
    [SerializeField]
    private bool m_OnDrugs;
    private float m_HueShiftValue;

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

        if (m_OnDrugs)
        {
            m_HueShiftValue -= 100 * Time.deltaTime;
            if(m_HueShiftValue <= -180)
            {
                m_HueShiftValue = 180;
            }
            var amount = test.colorGrading.settings;
            amount.basic.hueShift = m_HueShiftValue;
            test.colorGrading.settings = amount;
        }
        else
        {
            var amount = test.colorGrading.settings;
            amount.basic.hueShift = 0;
            test.colorGrading.settings = amount;
        }
    }
}


//[HelpURL("www.google.nl")]
//[DisallowMultipleComponent]
//[TextArea]