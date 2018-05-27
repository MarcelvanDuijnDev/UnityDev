using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private DamageHandler damageHandlerScript;
    private bool deadActivate;
    private string[] checkString;

    private float headShotSurviveChance;

	void Start ()
    {
        damageHandlerScript = this.gameObject.GetComponent<DamageHandler>();
        checkString = new string[4];
	}
	
	void Update ()
    {
		if(damageHandlerScript.dead)
        {
            if(!deadActivate)
            {
                Dead();
            }
        }
        HandleAnimations();
	}

    void Dead()
    {
        this.gameObject.AddComponent<Rigidbody>();
        GameObject systemObj = GameObject.Find("System");
        PlayerStatsCurrentGame playerScript = systemObj.GetComponent<PlayerStatsCurrentGame>();
        playerScript.AddMoney(100);
        playerScript.AddKill();
        playerScript.AddXP(100);
        deadActivate = true;
    }

    void HandleAnimations()
    {



        //Handle Damage
        if (damageHandlerScript.switchStateString.Contains("G")){checkString[0] = "G";}
        if (damageHandlerScript.switchStateString.Contains("FG")){checkString[0] = "FG";}
        if (damageHandlerScript.switchStateString.Contains("EFG")){checkString[0] = "EFG";}
        if (damageHandlerScript.switchStateString.Contains("DEFG")){checkString[0] = "DEFG";}

        switch (checkString[0]) //RightArm
        {
            case "G":
                Debug.Log("R Hand");
                break;
            case "FG":
                Debug.Log("R Lower Arm");
                break;
            case "EFG":
                Debug.Log("R Upper Arm");
                break;
            case "DEFG":
                Debug.Log("R Shoulder");
                break;
        }

        if (damageHandlerScript.switchStateString.Contains("K")){checkString[1] = "K";}
        if (damageHandlerScript.switchStateString.Contains("JK")){checkString[1] = "JK";}
        if (damageHandlerScript.switchStateString.Contains("IJK")){checkString[1] = "IJK";}
        if (damageHandlerScript.switchStateString.Contains("HIJK")){checkString[1] = "HIJK";}

        switch (checkString[1]) //LeftArm
        {
            case "K":
                Debug.Log("L Hand");
                break;
            case "JK":
                Debug.Log("L Lower Arm");
                break;
            case "IJK":
                Debug.Log("L Upper Arm");
                break;
            case "HIJK":
                Debug.Log("L Shoulder");
                break;
        }

        if (damageHandlerScript.switchStateString.Contains("Q")){checkString[2] = "Q";}
        if (damageHandlerScript.switchStateString.Contains("PQ")){checkString[2] = "QP";}
        if (damageHandlerScript.switchStateString.Contains("OPQ")){checkString[2] = "OPQ";}
        if (damageHandlerScript.switchStateString.Contains("NOPQ")){checkString[2] = "NOPQ";}

        switch (checkString[2]) //RightLeg
        {
            case "Q":
                Debug.Log("R Foot");
                break;
            case "PQ":
                Debug.Log("R Lower Leg");
                break;
            case "OPQ":
                Debug.Log("R Knee");
                break;
            case "NOPQ":
                Debug.Log("R UpperLeg");
                break;
        }

        if (damageHandlerScript.switchStateString.Contains("U")){checkString[3] = "U";}
        if (damageHandlerScript.switchStateString.Contains("TU")){checkString[3] = "TU";}
        if (damageHandlerScript.switchStateString.Contains("STU")){checkString[3] = "STU";}
        if (damageHandlerScript.switchStateString.Contains("RSTU")){checkString[3] = "RSTU";}

        switch (checkString[3]) //LefttLeg
        {
            case "U":
                Debug.Log("L Foot");
                break;
            case "TU":
                Debug.Log("L Lower Leg");
                break;
            case "STU":
                Debug.Log("L Knee");
                break;
            case "RSTU":
                Debug.Log("L UpperLeg");
                break;
        }
    }
}
