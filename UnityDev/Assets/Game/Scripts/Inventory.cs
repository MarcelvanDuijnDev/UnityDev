using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private GameObject m_CameraObject;
    public bool hasLog;
    public float log, rock, stick;


    private GetObject m_GetObjectScript;

	void Start ()
    {
        m_GetObjectScript = m_CameraObject.GetComponent<GetObject>();
	}
	
	void Update ()
    {
		

        if (m_GetObjectScript.hasLog)
        {
            hasLog = true;
            log = 1;
        }
        else
        {
            hasLog = false;
            log = 0;
        }
	}

    public void RemoveLog()
    {
        m_GetObjectScript.RemoveLog();
    }
}
