using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    public string nameGun;
    public string type;
    public int currentAmmo, currentClip;
    [SerializeField]private int maxAmmo, maxClipSize;
    [SerializeField]private float range;
    [SerializeField]private float damageAmount;
    [SerializeField]private float extraDamage;

    private void Start()
    {
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
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                    try
                    {
                        if (hit.transform.GetComponent<DamageHandler>() != null)
                        {
                            float damageExtra = extraDamage;
                            hit.transform.GetComponent<DamageHandler>().DoDamage(damageAmount * damageExtra, hit.transform.name);
                           
                        }
                    }
                    catch {}
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                }
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
}
