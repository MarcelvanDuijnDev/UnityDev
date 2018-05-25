using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField]
    private AddBodyPart[] addBodyPartScript;
    public bool dead;


    private void Update()
    {
        float checkIfDead = 0;
        for (int i = 0; i < addBodyPartScript.Length; i++)
        {
            if(addBodyPartScript[i].health <= 0)
            {
                checkIfDead += addBodyPartScript[i].priority;
            }
        }
        if(checkIfDead >= 100)
        {
            dead = true;
        }
    }

    public void DoDamage(float damageAmount, string objectName)
    {
        float damage = 0;
        Debug.Log("Damage: " + damageAmount);
        for (int i = 0; i < addBodyPartScript.Length; i++)
        {
            if(addBodyPartScript[i].bodyPart.transform.name == objectName)
            {
                if (damageAmount > addBodyPartScript[i].armor)
                {
                    damage = damageAmount - addBodyPartScript[i].armor;
                    addBodyPartScript[i].armor = 0;
                    addBodyPartScript[i].health -= damage;
                }
                else
                {
                    addBodyPartScript[i].armor -= damageAmount;
                }
            }
            if (addBodyPartScript[i].health <= 0)
            {
                for (int o = 0; o < addBodyPartScript[i].linkedObjects.Length; o++)
                {
                    for (int p = 0; p < addBodyPartScript.Length; p++)
                    {
                        if (addBodyPartScript[p].bodyPart == addBodyPartScript[i].linkedObjects[o])
                        {
                            addBodyPartScript[p].armor = 0;
                            addBodyPartScript[p].health = 0;
                        }
                    }
                }
            }
        }
    }
}

[System.Serializable]
public struct AddBodyPart
{
    public string info;
    public GameObject bodyPart;
    public float health;
    public float armor;
    public float priority;
    public GameObject[] linkedObjects;
}
