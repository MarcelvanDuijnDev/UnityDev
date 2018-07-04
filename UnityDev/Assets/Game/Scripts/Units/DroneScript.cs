using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour 
{
    [SerializeField]private float m_Speed;
    [SerializeField]private Vector3 m_StartPosition;
    [SerializeField]private Vector3 m_Destination;
    [SerializeField]private bool m_Delivered;
	
	void Update () 
    {
        if (!m_Delivered)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Destination, m_Speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, m_StartPosition, m_Speed);
        }
	}

    public void SetDestination(Vector3 destination)
    {
        m_Delivered = false;
        m_Destination = destination;
    }
}
