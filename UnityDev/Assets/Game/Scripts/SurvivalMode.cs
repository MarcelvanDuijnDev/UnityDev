using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalMode : MonoBehaviour
{
    ObjectPool_Script objectPoolScript;
    [SerializeField]private GameObject m_Player;
    [SerializeField]private GameObject[] m_ObjectPools;
    [SerializeField]private GameObject[] m_SpawnPostitions;
    [SerializeField]private float m_DifficultyIncrease;
    [SerializeField]private int m_EnemyStartAmount;

    private float m_Timer;
    private Vector2 m_Difficulty;
    private int m_NightSurvived;

    void Start ()
    {
        PlayerController playerScript = m_Player.GetComponent<PlayerController>();
	}
	
	void Update ()
    {
        m_Timer -= 1 * Time.deltaTime;
        if(m_Timer <= 0)
        {



            //Reset Spawn Timer
            m_Timer = Random.Range(m_Difficulty.x, m_Difficulty.y);
        }
	}

    void SpawnEnemy(int enemyID)
    {
        int spawnPos = Random.Range(0, m_SpawnPostitions.Length);
        for (int i = 0; i < objectPoolScript.objects.Count; i++)
        {
            if (!objectPoolScript.objects[i].activeInHierarchy)
            {
                objectPoolScript.objects[i].transform.position = m_SpawnPostitions[spawnPos].transform.position;
                objectPoolScript.objects[i].transform.rotation = transform.rotation;
                objectPoolScript.objects[i].SetActive(true);
                break;
            }
        }
    }
}
