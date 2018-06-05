using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private JsonSaveGameSettings JsonDataScript = new JsonSaveGameSettings();

    private void Start()
    {
        print(Application.persistentDataPath);
        Save();
        //Load();

    }

    private void Update()
    {

    }

    private void Save()
    {
        JsonDataScript.resolutions = 0;
        JsonDataScript.cursor = 0;

        JsonDataScript.playerName = "TestName";
        JsonDataScript.matchDifficulty = 0;
        JsonDataScript.healthMulti = 0;
        JsonDataScript.moneyMulti = 0;
        JsonDataScript.unlimmitedAmmo = false;

        string json = JsonUtility.ToJson(JsonDataScript);
        File.WriteAllText(Application.persistentDataPath + "/Settings.json", json.ToString());
        Debug.Log(Application.persistentDataPath + "/Settings.json");
    }
    private void Load()
    {
        string dataPath = Application.persistentDataPath +"Settings.json";
        string dataAsJson = File.ReadAllText(dataPath);
        JsonDataScript = JsonUtility.FromJson<JsonSaveGameSettings>(dataAsJson);
    }


}

public class JsonSaveGameSettings
{
    //Game Settings
    public int resolutions;
    public int cursor;

    //Match Settings
    public string playerName;
    public float matchDifficulty;
    public float healthMulti;
    public float moneyMulti;
    public bool unlimmitedAmmo;
}
