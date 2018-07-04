using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    [SerializeField]private Text m_PickupText;
    [SerializeField]private GameObject m_HoldItem;
    private GameObject otherObj;
    private bool m_Active;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            float dist = Vector3.Distance(hit.point, transform.position);
            if (dist <= 5)
            {
                if (hit.transform.gameObject.GetComponent<Pickupp>() != null)
                {
                    m_Active = true;
                }
                else
                {
                    m_Active = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            otherObj = null;
        }
        if (m_Active)
        {
            m_PickupText.text = "Press E to pickup";
            if(Input.GetKeyDown(KeyCode.E))
            {
                otherObj = hit.transform.gameObject;
            }
        }
        else
        {
            m_PickupText.text = "";
        }

        if (otherObj != null)
        {
            otherObj.transform.position = m_HoldItem.transform.position;
        }

    }
}
