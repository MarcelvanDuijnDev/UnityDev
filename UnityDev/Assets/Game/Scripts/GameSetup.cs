using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetup : MonoBehaviour 
{
    PlayerStats playerStatsScript;
    Settings settingsScript;
    ScoreBoard scoreBoardScript;

	void Start () 
    {
        playerStatsScript = this.gameObject.GetComponent<PlayerStats>();
        settingsScript = this.gameObject.GetComponent<Settings>();
        scoreBoardScript = this.gameObject.GetComponent<ScoreBoard>();

        LoadData();

    }
	
	void Update () 
    {
		
	}

    public void LoadData()
    {
        //Settings
        try
        {
            string dataPath = Application.persistentDataPath + "/Settings.json";
            string dataAsJson = File.ReadAllText(dataPath);
            Debug.Log("Very Nice");
        }
        catch
        {
            Debug.Log("Not Very Nice");
            settingsScript.CreateFile();
        }
        //PlayerStats
        try
        {
            string dataPath = Application.persistentDataPath + "/PlayerStats.json";
            string dataAsJson = File.ReadAllText(dataPath);
            Debug.Log("Very Nice");
        }
        catch
        {
            Debug.Log("Not Very Nice");
            playerStatsScript.CreateFile();
        }
        //ScoreBoard
        try
        {
            string dataPath = Application.persistentDataPath + "/Score.json";
            string dataAsJson = File.ReadAllText(dataPath);
            Debug.Log("Very Nice");
        }
        catch
        {
            Debug.Log("Not Very Nice");
            scoreBoardScript.CreateFile();
        }
    }
}

