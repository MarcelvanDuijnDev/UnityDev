using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuyMenu : MonoBehaviour 
{
    PlayerStatsCurrentGame playerScript;
    PlayerController playerControllerScript;
    Weapon weaponScript;
    public Text[] buttonsCostText;
    public Button[] buttons;
    public int[] prices;
    public int[] bought;
    public GameObject buyMenu;

	void Start () 
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        weaponScript = GameObject.Find("Weapon").GetComponent<Weapon>();
        playerScript = this.gameObject.GetComponent<PlayerStatsCurrentGame>();
        prices = new int[buttons.Length];
        bought = new int[buttons.Length];
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (buyMenu.gameObject.activeSelf)
            {
                buyMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                buyMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttonsCostText[i].text = prices[i].ToString();
            prices[i] = 0 * (bought[i] + 1);

            if (prices[i] <= playerScript.money)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }

        playerControllerScript.Upgrade(bought[3] * 5, bought[4] * 2.5f, bought[5] * 0.1f, bought[6] * 0.5f, bought[6] * 0.5f, bought[7] * 0.2f);
        weaponScript.Upgrade(bought[0] * 5, bought[1] * 10, bought[2] * 5);

	}

    public void BuyUpgrade(int upgradeID)
    {
        playerScript.money -= prices[upgradeID];
        bought[upgradeID] += 1;
    }
}
