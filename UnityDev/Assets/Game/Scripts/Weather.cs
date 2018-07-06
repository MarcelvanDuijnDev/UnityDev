using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    [SerializeField]private GameObject sunObj;
    [SerializeField]private Vector3 setTime;
    private float[] daysNeeded;
    private float m_TotalTime, m_Speed, m_TimeSpeed, m_TimePassed;
    private Light m_SunLight;

    [HideInInspector]public Vector3Int date;
    [HideInInspector]public Vector3 time;
    private bool sleep;

    void Start()
    {
        date = new Vector3Int(12,6,1674);
        time = new Vector3(0,0,0);
        m_TimePassed = 0;// 21300;
        //Get Light
        m_SunLight = sunObj.GetComponent<Light>();

        //Set days month
        daysNeeded = new float[12];
        daysNeeded[0] = 31;
        daysNeeded[1] = 28;
        daysNeeded[2] = 31;
        daysNeeded[3] = 30;
        daysNeeded[4] = 31;
        daysNeeded[5] = 30;
        daysNeeded[6] = 31;
        daysNeeded[7] = 31;
        daysNeeded[8] = 30;
        daysNeeded[9] = 31;
        daysNeeded[10] = 30;
        daysNeeded[11] = 31;

        m_Speed = 0.0041666f;
    }

    void Update()
    {
        //SetTime + speed
        m_TotalTime = setTime.x * 60 * 60 + setTime.y * 60 + setTime.z;
        m_TimeSpeed = 86400 / m_TotalTime;
        //Check Seconds Passed + Rotation
        m_TimePassed += m_TimeSpeed * Time.deltaTime;
        float test = m_TimePassed * m_Speed;
        sunObj.transform.localRotation = Quaternion.Euler(test,0,0);


        //Calculate Time
        time.z += m_TimeSpeed * Time.deltaTime;
        if (time.z >= 60)
        {
            time.z -= 60;
            time.y += 1;
        }
        if (time.y >= 60)
        {
            time.y = 0;
            time.x += 1;
        }
        //Calculate Day/Month/Year
        if (time.x >= 24)
        {
            time.x = 0;
            m_TimePassed = 0;
            date.x += 1;
        }
        if (date.x >= daysNeeded[date.y])
        {
            date.x = 1;
            date.y += 1;
        }
        if (date.y >= 13)
        {
            date.y = 1;
            date.x = 1;
            date.z += 1;
        }
            
        //Debug.Log("Speed: " + m_Speed + "  ||  " + "Time: " + m_TimePassed + "  ||  " + m_TimePassed * m_Speed );
       
        if(sleep)
        {

        }

    }

    public void Sleep(float sleepAmount)
    {
        sleep = true;
    }
}
