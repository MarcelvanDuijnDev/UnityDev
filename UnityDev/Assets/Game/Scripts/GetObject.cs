using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    [SerializeField]private GameObject m_System;
    [SerializeField]private GameObject m_Player;
    [SerializeField]private Text m_PickupText, m_PickupTextExtra;
    [SerializeField]private GameObject m_HoldItem;
    [SerializeField]private GameObject m_UIObject, m_UIObjectExtra;
    private GameObject otherObj;
    private bool m_Active;
    private string m_PickupInfo;

    private PlayerController m_PlayerScript;
    private Inventory m_InventoryScript;
    private Weather m_WeatherScript;

    private void Start()
    {
        m_PlayerScript = m_Player.GetComponent<PlayerController>();
        m_InventoryScript = m_Player.GetComponent<Inventory>();
        m_WeatherScript = m_System.GetComponent<Weather>();
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
                    m_PickupInfo = hit.transform.gameObject.GetComponent<Pickupp>().type;
                    m_Active = true;

                    if (m_PickupInfo == "Log")
                    {
                        m_PickupText.text = "Press E to pickup";
                    }
                    if (m_PickupInfo == "Stick" || m_PickupInfo == "Rock")
                    {
                        m_PickupText.text = "Press E to pickup";
                    }
                    if (m_PickupInfo == "Water")
                    {
                        m_PickupText.text = "Press E to Drink";
                    }
                    if (m_PickupInfo == "Hunger")
                    {
                        m_PickupText.text = "Press E to Eat";
                    }
                    if (m_PickupInfo == "House")
                    {
                        m_PickupText.text = "Press E to Save";
                        m_UIObjectExtra.SetActive(true);
                        m_PickupTextExtra.text = "Press Z to Sleep";
                    }
                }
                else
                {
                    m_UIObjectExtra.SetActive(false);
                    m_Active = false;
                }
            }
            else
            {
                m_UIObjectExtra.SetActive(false);
                m_Active = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            otherObj = null;
        }
        if (m_Active)
        {
            m_UIObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (m_PickupInfo == "Log")
                {
                    otherObj = hit.transform.gameObject;
                }
                if (m_PickupInfo == "Stick")
                {
                    m_InventoryScript.stick += hit.transform.gameObject.GetComponent<Pickupp>().amount;
                    hit.transform.gameObject.SetActive(false);
                }
                if (m_PickupInfo == "Rock")
                {
                    m_InventoryScript.rock += hit.transform.gameObject.GetComponent<Pickupp>().amount;
                    hit.transform.gameObject.SetActive(false);
                }
                if (m_PickupInfo == "Water")
                {
                    m_PlayerScript.AddThirst(hit.transform.gameObject.GetComponent<Pickupp>().amount);
                }
                if (m_PickupInfo == "Hunger")
                {
                    m_PlayerScript.AddThirst(hit.transform.gameObject.GetComponent<Pickupp>().amount);
                }
                if (m_PickupInfo == "House")
                {

                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                m_WeatherScript.Sleep(8);
            }
        }
        else
        {
            m_UIObject.SetActive(false);
        }

        if (otherObj != null)
        {
            otherObj.transform.position = m_HoldItem.transform.position;
        }

    }
}
