using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour 
{
    [SerializeField]private Vector3 m_RotationSpeed;

	void Update () 
    {
        this.transform.Rotate(m_RotationSpeed.x * Time.deltaTime, m_RotationSpeed.y * Time.deltaTime, m_RotationSpeed.z * Time.deltaTime);
	}
}
