using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField]
    private AddBodyPart[] addBodyPartScript;
    public bool dead;
    public string switchStateString;
    public float damageMulti;

    private void Update()
    {
        float checkIfDead = 0;
        string checkString = "";
        for (int i = 0; i < addBodyPartScript.Length; i++)
        {
            if(addBodyPartScript[i].health <= 0)
            {
                checkString += addBodyPartScript[i].bodyPartName;
                checkIfDead += addBodyPartScript[i].priority;
            }
            switchStateString = checkString;
        }
        if(checkIfDead >= 100)
        {
            dead = true;
        }
    }
        
    private void OnEnable()
    {
        dead = false;
        for (int i = 0; i < addBodyPartScript.Length; i++)
        {
            addBodyPartScript[i].health = addBodyPartScript[i].maxHealth;
        }
    }

    public void DoDamage(float damageAmount, string objectName)
    {
        float damage = 0;
        float damageAmountCalculated = damageAmount;// * damageMulti;
        Debug.Log(damageAmountCalculated);
        for (int i = 0; i < addBodyPartScript.Length; i++)
        {
            if (addBodyPartScript[i].bodyPart.transform.name == objectName)
            {
                if (damageAmountCalculated > addBodyPartScript[i].armor)
                {
                    damage = damageAmountCalculated - addBodyPartScript[i].armor;
                    addBodyPartScript[i].armor = 0;
                    addBodyPartScript[i].health -= damage;
                }
                else
                {
                    addBodyPartScript[i].armor -= damageAmountCalculated;
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
    public string bodyPartName;
    public GameObject bodyPart;
    public float maxHealth;
    public float health;
    public float armor;
    public float priority;
    public GameObject[] linkedObjects;
}
