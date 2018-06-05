using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [Header("Object Pool")]
    ObjectPool_Script objectPoolScript;
    public GameObject objectPool;
    private PlayerStatsCurrentGame playerScript;

    [Header("Options")]
    public int waveAmount;
    [SerializeField]private GameObject[] enemyPrefabs;
    [SerializeField]private Transform m_SpawnPosition;
    private Transform[] spawnPositions;

    //Cooldown
    [HideInInspector]public float cooldownTimer;
    private float cooldownTimerReset;
    [HideInInspector]public int currentWave;
    private float timer;
    [HideInInspector]public bool cooldown;
    private bool waveActive;

    [SerializeField]private float timeScale;
    [SerializeField]private int maxEnemyAlive;
    [SerializeField]private int[] enemyAmount;
    public int activeEnemys;
    public int[] killsNeeded;
    [HideInInspector]
    public float timerMatch;

    public int enemysAlive;


    private void Start()
    {
        Random.seed = 666;

        playerScript = this.gameObject.GetComponent<PlayerStatsCurrentGame>();
        objectPoolScript = (ObjectPool_Script)objectPool.GetComponent(typeof(ObjectPool_Script));
        spawnPositions = new Transform[m_SpawnPosition.transform.childCount];
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            spawnPositions[i] = m_SpawnPosition.transform.GetChild(i);
        }

        currentWave = 1;
        waveActive = true;
        cooldownTimerReset = cooldownTimer;
    }

    void Update()
    {
        timerMatch += 1 * Time.deltaTime;
        if (cooldown)
        {
            waveActive = false;
            cooldownTimer -= 1 * Time.deltaTime;
            if (cooldownTimer <= 0)
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
            enemysAlive = enemyAmount[currentWave -1] - playerScript.kills + killsNeeded[currentWave -1];
        }
        //
        if(killsNeeded[currentWave -1] == playerScript.kills)
        {
            cooldown = true;
        }
    }

    void ResetCooldown()
    {
        currentWave += 1;
        cooldown = false;
        waveActive = true;
        cooldownTimer = cooldownTimerReset;
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