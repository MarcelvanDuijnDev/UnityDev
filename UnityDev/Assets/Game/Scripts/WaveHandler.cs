using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField]private int waveAmount;
    [SerializeField]private GameObject[] enemyPrefabs;
    [SerializeField]private Transform[] spawnPositions;

    //Cooldown
    [SerializeField]private float cooldownTimer;
    private float cooldownTimerReset;
    private int currentWave;
    private float timer;
    private bool cooldown;
    private bool waveActive;

    [SerializeField]private float timeScale;
    [SerializeField]private int maxEnemyAlive;
    [SerializeField]private int[] enemyAmount;
    public int activeEnemys;

    private void Start()
    {
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
            if (enemyAmount[currentWave] > 0)
            {
                timer -= 1 * Time.deltaTime;
                if (timer <= 0)
                {
                    enemyAmount[currentWave] -= 1;
                    SpawnEnemy(0);
                    timer += Random.Range(0, timeScale);
                }
            }
        }
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
        Instantiate(enemyPrefabs[enemyID], spawnPositions[spawnPos].transform);
    }
}