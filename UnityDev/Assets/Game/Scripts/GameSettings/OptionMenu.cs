using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    Settings settingsScript;
    [SerializeField]private Dropdown m_GeneralSettings;
    [SerializeField]private Dropdown m_QualitySettings;
    [SerializeField]private Toggle m_DepthOfField;
    [SerializeField]private Toggle m_MotionBlur;
    [SerializeField]private Toggle m_Bloom;
    [SerializeField]private InputField m_ResolutionX,m_ResolutionY;

	void Start ()
    {
        settingsScript = this.gameObject.GetComponent<Settings>();
        settingsScript.LoadData();
        GetData();
    }
	
	void Update ()
    {
        settingsScript.JsonDataScript.graphics = m_QualitySettings.value;
        settingsScript.JsonDataScript.depthOfField = m_DepthOfField.isOn;
        settingsScript.JsonDataScript.motionBlur = m_MotionBlur.isOn;
        settingsScript.JsonDataScript.bloom = m_Bloom.isOn;
        settingsScript.JsonDataScript.resolutionX = int.Parse(m_ResolutionX.text);
        settingsScript.JsonDataScript.resolutionY = int.Parse(m_ResolutionY.text);

    }

    void GetData()
    {
        m_QualitySettings.value = settingsScript.JsonDataScript.graphics;
        m_DepthOfField.isOn = settingsScript.JsonDataScript.depthOfField;
        m_MotionBlur.isOn = settingsScript.JsonDataScript.motionBlur;
        m_Bloom.isOn = settingsScript.JsonDataScript.bloom;
        m_ResolutionX.text = settingsScript.JsonDataScript.resolutionX.ToString();
        m_ResolutionY.text = settingsScript.JsonDataScript.resolutionY.ToString();

    }
}
