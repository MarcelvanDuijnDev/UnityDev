using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour 
{
    Weather weatherScript;
    public Text dateText, timeText;
    private string dateString,timeString;

	void Start () 
    {
        weatherScript = this.gameObject.GetComponent<Weather>();
	}
	
	void Update () 
    {
        dateString = weatherScript.date.x.ToString() + "/" + weatherScript.date.y.ToString() + "/" + weatherScript.date.z.ToString();
        dateText.text = dateString;
        timeString = weatherScript.time.x.ToString("F0") + ":" + weatherScript.time.y.ToString("F0") + ":" + weatherScript.time.z.ToString("F00");
        timeText.text = timeString;
	}
}
