﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    public GameObject systemObj;
    public string nameGun;
    public string type;
    public float currentAmmo, currentClip;
    public int maxAmmo, maxClipSize;
    [SerializeField]private float range;
    [SerializeField]private float damageAmount;
    [SerializeField]private float extraDamage;
    private AudioScript audioScript;

    //Abilitys
    private bool m_InstaKill;

    //Upgrades
    private float m_DamageAmount_Upgrade;
    private int m_MaxClipSize_Upgrade;
    private int m_MaxAmmo_Upgrade;

    private void Start()
    {
        audioScript = systemObj.GetComponent<AudioScript>();
        currentClip = maxClipSize;
    }

    void Update () 
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (currentClip > 0)
            {
                currentClip -= 1;
                audioScript.PlaySound_GunShot(0, 0);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                    try
                    {
                        if (hit.transform.GetComponent<DamageHandler>() != null)
                        {
                            float damageExtra = extraDamage;
                            hit.transform.GetComponent<DamageHandler>().DoDamage(damageAmount + m_DamageAmount_Upgrade, hit.transform.name);
                        }
                        if(hit.transform.root.GetComponent<DamageHandler>() != null)
                        {
                            float damageExtra = extraDamage;
                            hit.transform.root.GetComponent<DamageHandler>().DoDamage(damageAmount + m_DamageAmount_Upgrade, hit.transform.name);
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                }
            }
            else
            {
                audioScript.PlaySound_EmptyGun(0, 0);
            }

            if(currentAmmo >= maxAmmo)
            {
                currentAmmo = maxAmmo;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(currentClip != maxClipSize)
            {
                if(currentAmmo >= maxClipSize - currentClip)
                {
                    currentAmmo -= maxClipSize - currentClip;
                    currentClip = maxClipSize;
                }
                else
                {
                    currentClip += currentAmmo;
                    currentAmmo = 0;
                }
            }
        }
        //Upgrades
        maxClipSize = 5 + m_MaxClipSize_Upgrade;
        maxAmmo = 50 + m_MaxAmmo_Upgrade;
	}

    public void UpgradeGun(int addMaxAmmo,int addMaxClipSize)
    {
        maxAmmo += addMaxAmmo;
        maxClipSize += addMaxClipSize;
    }

    public void SetValues(float setExtraDamage)
    {
        extraDamage = setExtraDamage;
    }

    public void Activate_InstaKill(bool state)
    {
        m_InstaKill = state;
    }

    public void Upgrade(int clipUpgrade,int ammoUpgrade, float damageUpgrade)
    {
        m_DamageAmount_Upgrade = damageUpgrade;
        m_MaxAmmo_Upgrade = ammoUpgrade;
        m_MaxClipSize_Upgrade = clipUpgrade;
    }
}
