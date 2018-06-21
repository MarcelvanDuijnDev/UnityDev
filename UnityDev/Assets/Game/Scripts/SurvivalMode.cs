using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalMode : MonoBehaviour
{
    ObjectPool_Script[] objectPoolScript;
    [SerializeField]private GameObject m_Player;
    [SerializeField]private GameObject[] m_ObjectPools;
    [SerializeField]private GameObject[] m_SpawnPostitions;
    [SerializeField]private float m_DifficultyIncrease;
    [SerializeField]private int m_EnemyStartAmount;

    private float m_Timer;
    [SerializeField]
    private Vector2 m_Difficulty;
    private int m_NightSurvived;

    void Start ()
    {
        PlayerController playerScript = m_Player.GetComponent<PlayerController>();
        objectPoolScript = new ObjectPool_Script[m_ObjectPools.Length];
        for (int i = 0; i < m_ObjectPools.Length; i++)
        {
            objectPoolScript[i] = m_ObjectPools[i].GetComponent<ObjectPool_Script>();
        }
	}
	
	void Update ()
    {
        m_Timer -= 1 * Time.deltaTime;
        if(m_Timer <= 0)
        {
            SpawnEnemy(0);


            //Reset Spawn Timer
            m_Timer = Random.Range(m_Difficulty.x, m_Difficulty.y);
        }
	}

    void SpawnEnemy(int enemyID)
    {
        int spawnPos = Random.Range(0, m_SpawnPostitions.Length);
        for (int i = 0; i < objectPoolScript[enemyID].objects.Count; i++)
        {
            if (!objectPoolScript[enemyID].objects[i].activeInHierarchy)
            {
                objectPoolScript[enemyID].objects[i].transform.position = m_SpawnPostitions[spawnPos].transform.position;
                objectPoolScript[enemyID].objects[i].transform.rotation = transform.rotation;
                objectPoolScript[enemyID].objects[i].SetActive(true);
                break;
            }
        }
    }
}
