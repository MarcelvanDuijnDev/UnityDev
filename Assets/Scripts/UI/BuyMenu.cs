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
    public Text[] prestigeText;
    public Button[] buttons;
    public int[] prices;
    public int[] bought;
    public GameObject buyMenu;
    public int prestige;

    // Prestige Upgrades
    private int magCapacity, ammoCapacity;
    private float damage, maxHealth, maxArmor, healthRegen;
    private float movement, jumpheight;

    private float extraMovement;
    private float extraJumpHeight;

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
        if (Input.GetKeyDown(KeyCode.Q))
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

        for (int i = 0; i < buttons.Length - 3; i++)
        {
            buttonsCostText[i].text = prices[i].ToString();
            prices[i] = 100 * (bought[i] + 1);

            if (prices[i] <= playerScript.money)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }

        //Prestige
        for (int i = 6; i < 9; i++)
        {
            buttonsCostText[i].text = prices[i].ToString();
            if (prices[i] <= playerScript.money)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
            prices[i] = 1000 * (bought[i] + 1);
        }

        magCapacity = bought[0] * 5;
        ammoCapacity = bought[1] * 10;
        damage = bought[2] * 5;
        maxHealth = bought[3] * 5;
        maxArmor = bought[4] * 2.5f;
        healthRegen = bought[5] * 0.25f;
        movement = extraMovement;
        jumpheight = extraJumpHeight;

        for (int i = 0; i < prestigeText.Length; i++)
        {
            if (prestige == 0)
            {
                prestigeText[0].text = "Double Jump";
                prestigeText[1].text = "...";
                prestigeText[2].text = "..";
            }
        }



        playerControllerScript.Upgrade(maxHealth, maxArmor, healthRegen, movement, movement, jumpheight);
        weaponScript.Upgrade(magCapacity, ammoCapacity, damage);



	}

    public void BuyUpgrade(int upgradeID)
    {
        playerScript.money -= prices[upgradeID];
        bought[upgradeID] += 1;
    }
}


/*
    mag     ammo    damage
    health  armor   Hregen

1:      Movementspeed   FireRate        BonusHeadshotDamage
2:      +Money          reloadspeed     every .. shot*damage
3:      






    movementspeed
    melee damage
    reloadspeed
    firerate
    every .. shot 2x damage
    bonus headshot damage
    more money
    stacking damage when headshot
    double jump



*/