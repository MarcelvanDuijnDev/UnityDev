using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    Settings settingsScript;
    [SerializeField]private Dropdown m_GeneralSettings;
    [SerializeField]private Dropdown m_QualitySettings;


	void Start ()
    {
        settingsScript = this.gameObject.GetComponent<Settings>();
        settingsScript.LoadData();
        GetData();
    }
	
	void Update ()
    {
        Debug.Log(m_GeneralSettings.value);

        settingsScript.JsonDataScript.graphics = m_QualitySettings.value;

    }

    public void SaveData()
    {
        settingsScript.SaveData();
    }

    void GetData()
    {
        m_QualitySettings.value = settingsScript.JsonDataScript.graphics;
    }
}
