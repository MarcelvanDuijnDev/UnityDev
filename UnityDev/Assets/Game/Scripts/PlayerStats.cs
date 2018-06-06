using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private JsonSavePlayerSettings JsonDataScript = new JsonSavePlayerSettings();
    [HideInInspector]
    public int lastPerk;
    private int currentPerk;
    private int totalKills;
    private float[] perkXPCurrent;
    public int[] perkLevel;
    [SerializeField]private float[] xpNeeded;
    [HideInInspector]public string currentPerkName;

    private void Start()
    {
        Save();
        xpNeeded = new float[100];
        for (int i = 0; i < xpNeeded.Length; i++)
        {
            xpNeeded[i] = i * 100;
        }
        Load();
    }

    private void Update()
    {
        for (int i = 0; i < xpNeeded.Length; i++)
        {
            if (perkLevel[0] == i && perkXPCurrent[0] >= xpNeeded[i])
            {
                perkXPCurrent[0] = 0;
                perkLevel[0]++;
                Save();
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Save();
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            perkXPCurrent[currentPerk] += 100;
        }

        currentPerkName = JsonDataScript.perks[currentPerk];
    }

    private void Save()
    {
        JsonDataScript.lastPerk = currentPerk;
        JsonDataScript.totalKills = totalKills;
        JsonDataScript.perks = new string[5];
        JsonDataScript.perkXP = new float[5];
        JsonDataScript.perkLevel = new int[5];
        for (int i = 0; i < perkXPCurrent.Length; i++)
        {
            JsonDataScript.perkLevel[i] = perkLevel[i];
            JsonDataScript.perkXP[i] = perkXPCurrent[i];
        }
        string json = JsonUtility.ToJson(JsonDataScript);
        File.WriteAllText(Application.persistentDataPath + "/PlayerStats.json", json.ToString());
    }
    private void Load()
    {
        string dataPath = Application.persistentDataPath +  "/PlayerStats.json";
        string dataAsJson = File.ReadAllText(dataPath);
        JsonDataScript = JsonUtility.FromJson<JsonSavePlayerSettings>(dataAsJson);
        perkXPCurrent = new float[JsonDataScript.perkXP.Length];
        perkLevel = new int[JsonDataScript.perkLevel.Length];
        for (int i = 0; i < perkXPCurrent.Length; i++)
        {
            perkXPCurrent[i] = JsonDataScript.perkXP[i];
            perkLevel[i] = JsonDataScript.perkLevel[i];
        }
        totalKills = JsonDataScript.totalKills;
        this.gameObject.GetComponent<PlayerStatsCurrentGame>().SetPlayerPerk();
        lastPerk = JsonDataScript.lastPerk;
    }

    public void AddXP(int perk, float xpAmount)
    {
        perkXPCurrent[perk] += xpAmount;
    }

    public void SetCurrentPerk(int perkIndex)
    {
        currentPerk = perkIndex;
    }

    public void AddKill()
    {
        totalKills++;
    }
}

public class JsonSavePlayerSettings
{
    public int lastPerk;
    public string[] perks;
    public int[] perkLevel;
    public float[] perkXP;
    public int totalKills;
}
