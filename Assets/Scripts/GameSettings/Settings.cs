using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [HideInInspector]public JsonSaveGameSettings JsonDataScript = new JsonSaveGameSettings();

    private void Start()
    {
        
        Load();
        SetGameSettings();
        Save();
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(JsonDataScript);
        File.WriteAllText(Application.persistentDataPath + "/Settings.json", json.ToString());
    }
    private void Load()
    {
        string dataPath = Application.persistentDataPath + "/Settings.json";
        string dataAsJson = File.ReadAllText(dataPath);
        JsonDataScript = JsonUtility.FromJson<JsonSaveGameSettings>(dataAsJson);
    }

    public void LoadData()
    {
        Load();
    }

    public void SaveData()
    {
        Save();
    }

    public void ApplyNewSettings()
    {
        bool restartScene = true;
        Save();
        SetGameSettings();
        if(restartScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetGameSettings()
    {
        if (JsonDataScript.fullscreen)
        {
            Screen.SetResolution(JsonDataScript.resolutionX, JsonDataScript.resolutionY, true);
        }
        else
        {
            Screen.SetResolution(JsonDataScript.resolutionX, JsonDataScript.resolutionY, false);
        }
        QualitySettings.SetQualityLevel(JsonDataScript.graphics);
        SetGraphics();

        /*
        QualitySettings.antiAliasing = 4;  // 0, 2, 4, 8
        QualitySettings.realtimeReflectionProbes = true;  // bool
        QualitySettings.shadowDistance = 1000;
        QualitySettings.vSyncCount = 60;
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
        */
    }
    private void SetGraphics()
    {
        if (GameObject.Find("Player_Camera") != null)
        {
            GameObject player = GameObject.Find("Player_Camera");
        }
    }

    //CreateFile
    public void CreateFile()
    {
        JsonDataScript.fullscreen = true;
        JsonDataScript.resolutionX = 1920;
        JsonDataScript.resolutionY = 1080;
        JsonDataScript.graphics = 5;
        string json = JsonUtility.ToJson(JsonDataScript);
        File.WriteAllText(Application.persistentDataPath + "/Settings.json", json.ToString());
    }
}

public class JsonSaveGameSettings
{
    //>>> Game Settings
    //General
    public bool fullscreen;
    public int resolutionX;
    public int resolutionY;
    public int graphics;
    public int cursor;

    //Audio
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    //Graphics
    public bool depthOfField;
    public bool motionBlur;
    public bool bloom;

    //>>> Match Settings
    public string playerName;
    public float matchDifficulty;
    public float healthMulti;
    public float moneyMulti;
    public bool unlimmitedAmmo;
}
