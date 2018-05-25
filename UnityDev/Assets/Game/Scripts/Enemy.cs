using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private DamageHandler damageHandlerScript;
    private bool deadActivate;

	void Start ()
    {
        damageHandlerScript = this.gameObject.GetComponent<DamageHandler>();
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
}
