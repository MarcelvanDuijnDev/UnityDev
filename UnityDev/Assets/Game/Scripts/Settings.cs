using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [HideInInspector]public JsonSaveGameSettings JsonDataScript = new JsonSaveGameSettings();

    private void Start()
    {
        print(Application.persistentDataPath);
        Load();
        SetGameSettings();
    }

    private void Save()
    {
        JsonDataScript.securityCode = new string[10];
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

    public void SetGameSettings()
    {
        if (JsonDataScript.fullscreen)
        {
            Screen.SetResolution(JsonDataScript.resolutions.x, JsonDataScript.resolutions.y, true);
        }
        else
        {
            Screen.SetResolution(JsonDataScript.resolutions.x, JsonDataScript.resolutions.y, false);
        }
        QualitySettings.SetQualityLevel(JsonDataScript.graphics);
    }
}

public class JsonSaveGameSettings
{
    //>>> Game Settings
    //General
    public bool fullscreen;
    public Vector2Int resolutions;
    public int graphics;
    public int cursor;
    //Audio
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;



    //>>> Match Settings
    public string playerName;
    public float matchDifficulty;
    public float healthMulti;
    public float moneyMulti;
    public bool unlimmitedAmmo;

    public string[] securityCode;
}
