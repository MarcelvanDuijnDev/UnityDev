using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : MonoBehaviour
{
    [Header("Needed")]
    public float stick;
    public float rock, log;
    [Header("Got")]
    [SerializeField]private float m_Sticks;
    [SerializeField]private float m_Rocks, m_Logs;

    [HideInInspector]
    public bool gotSticks, gotRocks, gotLogs;

    [Header("Build options")]
    [SerializeField]private GameObject[] m_Build_Sticks, m_Build_Rocks, m_Build_Logs;

    void Update ()
    {
        if (m_Sticks == stick && m_Rocks == rock && m_Logs == log)
        {
            Debug.Log(transform.name + "   Build");
        }

        
	}

    public void AddStick()
    {
        m_Sticks += 1;
    }
    public void AddRock()
    {
        m_Rocks += 1;
    }
    public void AddLog()
    {
        m_Logs += 1;
    }
    
}
