using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private bool isPauzeMenu;
    [SerializeField]private GameObject pauzeMenuObj;
    [SerializeField]private GameObject optionsMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPauzeMenu)
        {
            if(pauzeMenuObj.activeSelf)
            {
                if (!optionsMenu.activeSelf)
                {
                    pauzeMenuObj.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Time.timeScale = 1;
                }
            }
            else
            {
                pauzeMenuObj.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
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
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
