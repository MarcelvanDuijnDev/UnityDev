using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private bool isPauzeMenu;
    [SerializeField]
    private GameObject pauzeMenuObj;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPauzeMenu)
        {
            if(pauzeMenuObj.activeSelf)
            {
                pauzeMenuObj.SetActive(false);
            }
            else
            {
                pauzeMenuObj.SetActive(true);
            }
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauzeMenuObj.SetActive(false);
    }
}
