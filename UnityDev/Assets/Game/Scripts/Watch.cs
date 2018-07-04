using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Watch : MonoBehaviour 
{
    [Header("Scripts")]
    [SerializeField]private Weather weatherScript;
    [Header("Info1")]
    [SerializeField]private GameObject[] Screens;
    [Header("Buttons")]
    [SerializeField]private GameObject buttonsObj;
    [Header("Time/Date")]
    [SerializeField]private Text dateText;
    [SerializeField]private Text timeText;
    private string dateString,timeString;

    void Start () 
    {
	}
	
	void Update () 
    {
        dateString = weatherScript.date.x.ToString() + "/" + weatherScript.date.y.ToString() + "/" + weatherScript.date.z.ToString();
        dateText.text = dateString;
        timeString = weatherScript.time.x.ToString("F0") + ":" + weatherScript.time.y.ToString("F0") + ":" + weatherScript.time.z.ToString("F0");
        timeText.text = timeString;
    }

    public void ClickOnButton(int screenID)
    {
        for (int i = 0; i < Screens.Length; i++)
        {
            if (i == screenID)
            {
                Screens[i].SetActive(true);
            }
            else
            {
                Screens[i].SetActive(false);
            }
        }
    }
    public void ClickOnButton_ButtonsActive(bool buttonsActive)
    {
        if (buttonsActive)
        {
            buttonsObj.SetActive(true);
        }
        else
        {
            buttonsObj.SetActive(false);
        }
    }
}
