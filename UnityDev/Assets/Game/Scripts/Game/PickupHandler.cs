using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour 
{
    [SerializeField]private GameObject[] pickups;
    [SerializeField]private float[] timer;
    private float[] timerReset;

	void Start () 
    {
        timerReset = new float[timer.Length];
        for (int i = 0; i < timer.Length; i++)
        {
            timerReset[i] = timer[i];
        }
	}
	
	void Update () 
    {
        for (int i = 0; i < pickups.Length; i++)
        {
            if (!pickups[i].gameObject.activeSelf)
            {
                timer[i] -= 1 * Time.deltaTime;
                if (timer[i] <= 0)
                {
                    pickups[i].gameObject.SetActive(true);
                    timer[i] = timerReset[i];
                }
            }
        }
	}
}
