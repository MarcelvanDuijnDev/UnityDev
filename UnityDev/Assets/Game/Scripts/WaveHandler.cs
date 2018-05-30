using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [Header("Object Pool")]
    ObjectPool_Script objectPoolScript;
    public GameObject objectPool;

    [Header("Options")]
    public int waveAmount;
    [SerializeField]private GameObject[] enemyPrefabs;
    [SerializeField]private Transform[] spawnPositions;

    //Cooldown
    [SerializeField]private float cooldownTimer;
    private float cooldownTimerReset;
    [HideInInspector]public int currentWave;
    private float timer;
    private bool cooldown;
    private bool waveActive;

    [SerializeField]private float timeScale;
    [SerializeField]private int maxEnemyAlive;
    [SerializeField]private int[] enemyAmount;
    public int activeEnemys;

    private int killsNeeded;
    private bool killsNeededSet;

    private void Start()
    {
        objectPoolScript = (ObjectPool_Script)objectPool.GetComponent(typeof(ObjectPool_Script));

        currentWave = 1;
        waveActive = true;
        cooldownTimerReset = cooldownTimer;
    }

    void Update()
    {
        if(cooldown)
        {
            cooldownTimer -= 1 * Time.deltaTime;
            if(cooldownTimer <= 0)
            {
                ResetCooldown();
            }
        }
        if(waveActive)
        {
            if (enemyAmount[currentWave - 1] > 0)
            {
                timer -= 1 * Time.deltaTime;
                if (timer <= 0)
                {
                    enemyAmount[currentWave - 1] -= 1;
                    SpawnEnemy(0);
                    timer += Random.Range(0, timeScale);
                }
            }
            if(!killsNeededSet)
            {
                SetKillsNeeded();
            }
        }
    }

    void SetKillsNeeded()
    {
        killsNeeded += enemyAmount[currentWave - 1];
        killsNeededSet = false;
    }

    void ResetCooldown()
    {
        cooldownTimer = cooldownTimerReset;
        cooldown = false;
        waveActive = true;
    }

    void SpawnEnemy(int enemyID)
    {
        int spawnPos = Random.Range(0, spawnPositions.Length);
        for (int i = 0; i < objectPoolScript.objects.Count; i++)
        {
            if (!objectPoolScript.objects[i].activeInHierarchy)
            {
                objectPoolScript.objects[i].transform.position = spawnPositions[spawnPos].position;
                objectPoolScript.objects[i].transform.rotation = transform.rotation;
                objectPoolScript.objects[i].SetActive(true);
                break;
            }
        }
    }
}