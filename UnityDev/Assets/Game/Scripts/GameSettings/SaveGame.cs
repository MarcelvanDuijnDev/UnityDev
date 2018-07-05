using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    [SerializeField]private bool isMenu;
    private JsonSaveGame JsonDataScript = new JsonSaveGame();
    private int totalKills;

    private void Start()
    {
        if (!isMenu)
        {
            Load();
        }
    }

    private void Update()
    {
        if (!isMenu)
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                Save();
            }
        }
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(JsonDataScript);
        File.WriteAllText(Application.persistentDataPath + "/SaveGame.json", json.ToString());
    }
    private void Load()
    {
        string dataPath = Application.persistentDataPath +  "/SaveGame.json";
        string dataAsJson = File.ReadAllText(dataPath);
        JsonDataScript = JsonUtility.FromJson<JsonSaveGame>(dataAsJson);
    }

    public void AddKill()
    {
        totalKills++;
    }

    public void CreateFile()
    {
        JsonDataScript.saveName = new string[5];
        JsonDataScript.saveName[0] = "Save1";
        JsonDataScript.saveName[1] = "Save2";
        JsonDataScript.saveName[2] = "Save3";
        JsonDataScript.saveName[3] = "Save4";
        JsonDataScript.saveName[4] = "Save5";
        Save();
    }
}

public class JsonSaveGame
{
    public string[] saveName;
}
