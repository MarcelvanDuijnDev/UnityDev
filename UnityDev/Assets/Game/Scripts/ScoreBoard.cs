using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private JsonSaveScoreData JsonDataScript = new JsonSaveScoreData();
    public JsonScoreData[] jsonScript;
    public bool save, reset;

    private void Start()
    {
        //Save();
        Load();
    }

    private void Update()
    {
        if(save)
        {
            Save();
        }
        if(reset)
        {
            ResetScoreAll();
        }
    }

    private void Save()
    {
        JsonDataScript.jsonScoreDataScript = jsonScript;
        string json = JsonUtility.ToJson(JsonDataScript);
        File.WriteAllText(Application.persistentDataPath + "/Score.json", json.ToString());
    }
    private void Load()
    {
        string dataPath =Application.persistentDataPath + "/Score.json";
        string dataAsJson = File.ReadAllText(dataPath);
        JsonDataScript = JsonUtility.FromJson<JsonSaveScoreData>(dataAsJson);
    }

    public void SaveScore(int mapID,int score)
    {
        if (score >= JsonDataScript.jsonScoreDataScript[mapID].score)
        {
            JsonDataScript.jsonScoreDataScript[mapID].kills = this.gameObject.GetComponent<PlayerStatsCurrentGame>().kills;
            JsonDataScript.jsonScoreDataScript[mapID].timeSurvived = this.gameObject.GetComponent<WaveHandler>().timerMatch;
            JsonDataScript.jsonScoreDataScript[mapID].score = score;
        }
        Save();
    }

    public void ResetScore(int mapID)
    {
        JsonDataScript.jsonScoreDataScript[mapID].kills = 0;
        JsonDataScript.jsonScoreDataScript[mapID].timeSurvived = 0;
        JsonDataScript.jsonScoreDataScript[mapID].score = 0;
    }


    public void ResetScoreAll()
    {
        for (int i = 0; i < 5; i++)
        {
            ResetScore(i);
        }
    }

    public void Dead(int mapID)
    {
        int scoreT = this.gameObject.GetComponent<PlayerStatsCurrentGame>().score;
        SaveScore(mapID, scoreT);
    }
}

public class JsonSaveScoreData
{
    public JsonScoreData[] jsonScoreDataScript;
}

[System.Serializable]
public class JsonScoreData
{
    public int kills;
    public int score;
    public float timeSurvived;
}