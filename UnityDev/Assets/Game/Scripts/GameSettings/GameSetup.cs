using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    public void LoadData()
    {
        //Settings
        try
        {
            string dataPath = Application.persistentDataPath + "/Settings.json";
            string dataAsJson = File.ReadAllText(dataPath);
            Debug.Log("Settings.json Found");
        }
        catch
        {
            Debug.Log("Settings.json Created");
            settingsScript.CreateFile();
            SceneManager.LoadScene(0);
        }
        //PlayerStats
        try
        {
            string dataPath = Application.persistentDataPath + "/PlayerStats.json";
            string dataAsJson = File.ReadAllText(dataPath);
            Debug.Log("PlayerStats.json Found");
        }
        catch
        {
            Debug.Log("PlayerStats.json Created");
            playerStatsScript.CreateFile();
            SceneManager.LoadScene(0);
        }
        //ScoreBoard
        try
        {
            string dataPath = Application.persistentDataPath + "/Score.json";
            string dataAsJson = File.ReadAllText(dataPath);
            Debug.Log("Score.json Found");
        }
        catch
        {
            Debug.Log("Score.json Created");
            scoreBoardScript.CreateFile();
            SceneManager.LoadScene(0);
        }
    }
}

