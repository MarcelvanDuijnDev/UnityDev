using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    [SerializeField]private GameObject sunObj;
    [SerializeField]private Vector3 m_Time;
    [SerializeField]private int m_DaysInYear;
    [SerializeField]private int m_CurrentYear, m_CurrentDay;

    private float m_TotalTime, speed, m_TimeCalculate;
    private Light m_SunLight;

    void Start()
    {
        m_SunLight = sunObj.GetComponent<Light>();

        m_TotalTime += m_Time.x * 60 * 60;
        m_TotalTime += m_Time.y * 60;
        m_TotalTime += m_Time.z;
        m_TimeCalculate = m_TotalTime;
        speed = 360 / m_TotalTime;
        m_CurrentDay = 1;
    }

    void Update()
    {
        sunObj.transform.Rotate(Vector3.right * speed * Time.deltaTime);

        //Calculate Day/Year
        m_TimeCalculate -= 1 * Time.deltaTime;
        if (m_TimeCalculate <= 0)
        {
            m_CurrentDay += 1;
            m_TimeCalculate = m_TotalTime;
        }
        if (m_CurrentDay >= m_CurrentYear)
        {
            m_CurrentYear += 1;
            m_CurrentDay = 1;
        }

        //Weather state
        
        //rain emmision rate
    }
}
