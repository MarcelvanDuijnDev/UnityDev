using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStatsCurrentGame : MonoBehaviour
{
    private int currentPerk;
    [HideInInspector]public int money;
    [HideInInspector]public int kills;
    public int score;
    private PlayerStats playerScript;
    private WaveHandler waveHandlerScript;
    [SerializeField]private Text healthText, armorText;
    [SerializeField]private Text moneyText, killsText;
    [SerializeField]private Text playerPerkLevel, playerCurrentPerkName;
    [SerializeField]private Text weaponName, weaponAmmo, weaponClip;
    [SerializeField]private Text waveText, waveAmountText;
    [SerializeField]private Text cooldownText;
    [SerializeField]private GameObject player;
    [SerializeField]private PlayerController playerControllerScript;
    [SerializeField]private Weapon weaponScript;

    void Start()
    {
        playerScript = this.gameObject.GetComponent<PlayerStats>();
        waveHandlerScript = this.gameObject.GetComponent<WaveHandler>();
    }
	
	void Update ()
    {
        SetCurrentPerk(playerScript.lastPerk);
        moneyText.text = "$: " + money.ToString();
        killsText.text = "Kills: " + kills.ToString();
        playerPerkLevel.text = "PerkLevel: " + playerScript.perkLevel[currentPerk].ToString();
        playerCurrentPerkName.text = playerScript.currentPerkName.ToString();

        weaponName.text = "" + weaponScript.nameGun;
        weaponAmmo.text = "Ammo: " + weaponScript.currentAmmo + " / " + weaponScript.maxAmmo;
        weaponClip.text = "Clip: " + weaponScript.currentClip;

        healthText.text = "+ " + playerControllerScript.health.ToString();
        armorText.text = "[] " + playerControllerScript.armor.ToString();

        waveText.text = waveHandlerScript.currentWave.ToString() + "/" + waveHandlerScript.waveAmount.ToString();
        waveAmountText.text = waveHandlerScript.enemysAlive.ToString();

        //Cooldown
        if(waveHandlerScript.cooldown)
        {
            cooldownText.text = waveHandlerScript.cooldownTimer.ToString("F0");
        }
        else
        {
            cooldownText.text = "";
        }
    }

    public void AddMoney(int moneyAmount)
    {
        money += moneyAmount;
    }

    public void AddXP(float xpAmount)
    {
        playerScript.AddXP(currentPerk, xpAmount);
    }

    public void AddKill()
    {
        kills++;
        playerScript.AddKill();
        score += 100;
    }

    public void SetCurrentPerk(int perkIndex)
    {
        //currentPerk = perkIndex;
        playerScript.SetCurrentPerk(perkIndex);
        SetPlayerPerk();
    }

    public void SetPlayerPerk()
    {
        /*
        float extraDamage = 1;
        float normalSpeed = 5;
        float sprintSpeed = 8;

        if(currentPerk == 0) //Commando
        {
            extraDamage += 0.0f * playerScript.perkLevel[currentPerk];
            normalSpeed += 0.05f * playerScript.perkLevel[currentPerk];
            sprintSpeed += 0.06f * playerScript.perkLevel[currentPerk];
            playerControllerScript.SetValues(normalSpeed,sprintSpeed);
            weaponScript.SetValues(extraDamage);
        }
        */

    }
}
