using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Watch : MonoBehaviour 
{
    [Header("Scripts")]
    [SerializeField]private Weather weatherScript;
    [Header("Buttons")]
    [SerializeField]private GameObject buttonsObj;
    [Header("HomeScreen")]
    [SerializeField]private GameObject homeScreenObj;
    [SerializeField]private Text dateText, timeText;
    private string dateString,timeString;
    [Header("Info1")]
    [SerializeField]private GameObject Info1Obj;
    [Header("Info2")]
    [SerializeField]private GameObject Info2Obj;
    [Header("Options")]
    [SerializeField]private GameObject optionsObj;

    void Start () 
    {
	}
	
	void Update () 
    {
        dateString = weatherScript.date.x.ToString() + "/" + weatherScript.date.y.ToString() + "/" + weatherScript.date.z.ToString();
        dateText.text = dateString;
        timeString = weatherScript.time.x.ToString("F0") + ":" + weatherScript.time.y.ToString("F0") + ":" + weatherScript.time.z.ToString("F0");
        timeText.text = timeString;

        if(Input.GetKeyDown(KeyCode.Less))
        {
            Time.timeScale -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Greater))
        {
            Time.timeScale += 0.1f;
        }
    }

    public void ClickOnButton(int screenID)
    {
        if(screenID == 0)
        {
            homeScreenObj.SetActive(true);
            Info1Obj.SetActive(false);
            Info2Obj.SetActive(false);
            optionsObj.SetActive(false);
            buttonsObj.SetActive(true);
        }
        if(screenID == 1)
        {
            homeScreenObj.SetActive(false);
            Info1Obj.SetActive(true);
            Info2Obj.SetActive(false);
            optionsObj.SetActive(false);
        }
        if(screenID == 2)
        {
            homeScreenObj.SetActive(false);
            Info1Obj.SetActive(false);
            Info2Obj.SetActive(true);
            optionsObj.SetActive(false);
        }
        if (screenID == 3)
        {
            homeScreenObj.SetActive(false);
            Info1Obj.SetActive(false);
            Info2Obj.SetActive(false);
            optionsObj.SetActive(true);
            buttonsObj.SetActive(false);
        }
    }
}
