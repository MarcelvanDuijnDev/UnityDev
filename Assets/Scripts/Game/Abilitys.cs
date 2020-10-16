using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilitys : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private float m_TimerMulti;
    private PlayerController m_PlayerScript;
    private Weapon m_WeaponScript;

    private float[] m_Ability;


	void Start ()
    {
        m_PlayerScript = player.gameObject.GetComponent<PlayerController>();
        m_WeaponScript = player.gameObject.GetComponentInChildren<Weapon>();
	}
	
	void Update ()
    {
        for (int i = 0; i < m_Ability.Length; i++)
        {
            if (m_Ability[i] > 0)
            {
                if (i == 0) { m_WeaponScript.Activate_InstaKill(true);}
                m_Ability[i] -= 1 * Time.deltaTime;
            }
            else
            {
                if (i == 0) { m_WeaponScript.Activate_InstaKill(false);}
            }
        }
	}

    public void Activate(int AbilityID)
    {
        m_Ability[AbilityID] = 60 * m_TimerMulti;
    }
}

/*
Abilitys
0 = InstaKill
1 = HealthRegen
2 = InstaMaxHealth
3 = MovementSpeed
4 = InstaMaxAmmo
5 = Nuke



*/