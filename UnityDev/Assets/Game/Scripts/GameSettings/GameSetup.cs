using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine;

public class GameSetup : MonoBehaviour 
{
    SaveGame saveGameScript;
    Settings settingsScript;

	void Start () 
    {
        saveGameScript = this.gameObject.GetComponent<SaveGame>();
        settingsScript = this.gameObject.GetComponent<Settings>();
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
            string dataPath = Application.persistentDataPath + "/SaveGame.json";
            string dataAsJson = File.ReadAllText(dataPath);
            Debug.Log("SaveGame.json Found");
        }
        catch
        {
            Debug.Log("SaveGame.json Created");
            saveGameScript.CreateFile();
            SceneManager.LoadScene(0);
        }
    }
}

