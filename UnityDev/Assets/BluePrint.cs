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

    [Header("Build BluePrint")]
    [SerializeField]private GameObject[] m_Build_Sticks;
    [SerializeField]private GameObject[] m_Build_Rocks, m_Build_Logs;

    [Header("Build Final")]
    [SerializeField]private GameObject[] m_Build_SticksFinal;
    [SerializeField]private GameObject[] m_Build_RocksFinal, m_Build_LogsFinal;

    private BuildManager m_BuildManager;

    void Start()
    {
        m_BuildManager = GameObject.Find("System").GetComponent<BuildManager>();

        m_BuildManager.logNeeded = m_BuildManager.logNeeded + log - m_Logs;
        m_BuildManager.sticksNeeded = m_BuildManager.sticksNeeded + stick - m_Sticks;
        m_BuildManager.rocksNeeded = m_BuildManager.rocksNeeded + rock - m_Rocks;
    }

    void Update ()
    {
        if (log == m_Logs)
        {
            gotLogs = true;
        }
        if (stick == m_Sticks)
        {
            gotSticks = true;
        }
        if (rock == m_Rocks)
        {
            gotRocks = true;
        }
	}

    public void AddLog()
    {
        m_Logs += 1;
        m_BuildManager.logNeeded -= 1;
        for (int i = 0; i < m_Build_Logs.Length; i++)
        {
            if (i == m_Logs -1)
            {
                m_Build_Logs[i].SetActive(false);
                m_Build_LogsFinal[i].SetActive(true);
            }
        }
    } 
    public void AddStick()
    {
        m_Sticks += 1;
        m_BuildManager.sticksNeeded -= 1;
        for (int i = 0; i < m_Build_Sticks.Length; i++)
        {
            if (i == m_Sticks -1)
            {
                m_Build_Sticks[i].SetActive(false);
                m_Build_SticksFinal[i].SetActive(true);
            }
        }
    }
    public void AddRock()
    {
        m_Rocks += 1;
        m_BuildManager.rocksNeeded -= 1;
        for (int i = 0; i < m_Build_Rocks.Length; i++)
        {
            if (i == m_Rocks -1)
            {
                m_Build_Rocks[i].SetActive(false);
                m_Build_RocksFinal[i].SetActive(true);
            }
        }
    }
}
