using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour 
{
    [SerializeField]private GameObject m_Player;
    [SerializeField]private float m_Speed;
    [SerializeField]private Vector3 m_StartPosition;
    [SerializeField]private Vector3 m_Destination;
    [SerializeField]private bool m_Delivered;
    [SerializeField]private GameObject m_Package, m_NewPackage;

    void Update()
    {
        if (!m_Delivered)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Destination, m_Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, m_StartPosition, m_Speed * Time.deltaTime);
        }

        if (transform.position == m_Destination)
        {

                GameObject Package = m_NewPackage;
                Package.transform.position = Package.transform.position;
                Package.name = "Package";
                Debug.Log("Package");

            m_Delivered = true;
            m_Package.SetActive(false);
        }

        if (transform.position == m_StartPosition)
        {
            m_Package.SetActive(true);
        }
    }

    public void SetDestination()
    {
        m_Destination = m_Player.transform.position;
        m_Destination.y += 5;
        m_Delivered = false;
    }
}
