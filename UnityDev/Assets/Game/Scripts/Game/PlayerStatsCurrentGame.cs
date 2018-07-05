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
    private SaveGame playerScript;
    private WaveHandler waveHandlerScript;
    [SerializeField]private Text healthText, armorText;
    [SerializeField]private Text thirstText, hungerText;
    [SerializeField]private Text moneyText, killsText;
    [SerializeField]private Text playerName;
    [SerializeField]private Text weaponName, weaponAmmo, weaponClip;
    [SerializeField]private Text cooldownText;
    [SerializeField]private GameObject player;
    [SerializeField]private Text logsText, sticksText, rocksText;
    private PlayerController playerControllerScript;
    private Inventory inventoryScript;
    private BuildManager buildManagerScript;
    //private Weapon weaponScript;

    void Start()
    {
        playerControllerScript = player.gameObject.GetComponent<PlayerController>();
        inventoryScript = player.gameObject.GetComponent<Inventory>();
        buildManagerScript = this.gameObject.GetComponent<BuildManager>();
        //weaponScript = GameObject.Find("Weapon").GetComponent<Weapon>();
        playerScript = this.gameObject.GetComponent<SaveGame>();
        waveHandlerScript = this.gameObject.GetComponent<WaveHandler>();
    }
	
	void Update ()
    {
        moneyText.text = "$: " + money.ToString();
        killsText.text = "Kills: " + kills.ToString();

        //weaponName.text = "" + weaponScript.nameGun;
        //weaponAmmo.text = "Ammo: " + weaponScript.currentAmmo + " / " + weaponScript.maxAmmo;
        //weaponClip.text = "Clip: " + weaponScript.currentClip + " / " + weaponScript.maxClipSize;

        healthText.text = "Health: " + playerControllerScript.health.ToString("F0");
        armorText.text = "Armor: " + playerControllerScript.armor.ToString("F0");
        thirstText.text = "Thirst: " + playerControllerScript.thirst.ToString("F0");
        hungerText.text = "Hunger: " + playerControllerScript.hunger.ToString("F0");

        //Items
        logsText.text = "Logs(" + inventoryScript.log.ToString() + "/" + buildManagerScript.logNeeded.ToString() + ")";
        sticksText.text = "Sticks(" + inventoryScript.stick.ToString() + "/" + buildManagerScript.sticksNeeded.ToString() + ")";
        rocksText.text = "Rocks(" + inventoryScript.rock.ToString() + "/" + buildManagerScript.rocksNeeded.ToString() + ")";
    }

    public void AddMoney(int moneyAmount)
    {
        money += moneyAmount;
    }

    public void AddKill()
    {
        kills++;
        playerScript.AddKill();
        score += 100;
    }
}
