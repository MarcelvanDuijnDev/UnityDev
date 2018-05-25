using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStatsCurrentGame : MonoBehaviour
{
    private int currentPerk;
    private int money;
    private int kills;
    private PlayerStats playerScript;
    [SerializeField]private Text moneyText, killsText;
    [SerializeField]private Text playerPerkLevel;
    [SerializeField]private Text weaponName, weaponAmmo, weaponClip;
    [SerializeField]private GameObject player;
    [SerializeField]private PlayerController playerControllerScript;
    [SerializeField]private Weapon weaponScript;

    void Start()
    {
        playerScript = this.gameObject.GetComponent<PlayerStats>();
        SetPlayerPerk();
    }
	
	void Update ()
    {
        moneyText.text = "Money: " + money.ToString();
        killsText.text = "Kills: " + kills.ToString();
        playerPerkLevel.text = "PerkLevel: " + playerScript.perkLevel[currentPerk].ToString();

        weaponName.text = "" + weaponScript.nameGun;
        weaponAmmo.text = "Ammo: " + weaponScript.currentAmmo;
        weaponClip.text = "Clip: " + weaponScript.currentClip;

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
    }

    public void SetPlayerPerk()
    {
        float extraDamage = 0;
        float normalSpeed = 5;
        float sprintSpeed = 8;
        if(currentPerk == 0)
        {
            extraDamage += 0.1f * playerScript.perkLevel[currentPerk];
            normalSpeed += 0.05f * playerScript.perkLevel[currentPerk];
            sprintSpeed += 0.06f * playerScript.perkLevel[currentPerk];
            playerControllerScript.SetValues(normalSpeed,sprintSpeed);
            weaponScript.SetValues(extraDamage);
        }
    }
}
