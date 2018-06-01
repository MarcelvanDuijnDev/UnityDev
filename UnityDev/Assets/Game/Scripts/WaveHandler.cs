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
    [SerializeField]private Transform[] spawnPositions;

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

    private void Start()
    {
        playerScript = this.gameObject.GetComponent<PlayerStatsCurrentGame>();
        objectPoolScript = (ObjectPool_Script)objectPool.GetComponent(typeof(ObjectPool_Script));

        currentWave = 1;
        waveActive = true;
        cooldownTimerReset = cooldownTimer;
    }

    void Update()
    {
        if(cooldown)
        {
            waveActive = false;
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
        }
        //
        Debug.Log(playerScript.kills);
        Debug.Log(killsNeeded[currentWave -1]);
        Debug.Log(currentWave);
        if(killsNeeded[currentWave -1] == playerScript.kills)
        {
            cooldown = true;
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