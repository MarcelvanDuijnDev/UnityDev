using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour 
{
    [SerializeField]private GameObject treeObj;
    [SerializeField]private GameObject[] treeObjects;
    [SerializeField]private float treeHealth;
    private float timer;

	void Start () 
    {
        timer = 10;
	}
	
	void Update () 
    {
		
        if (treeHealth <= 0)
        {
            timer -= 1 * Time.deltaTime;

            if (timer <= 0)
            {
                if (treeObj.GetComponent<Rigidbody>() == null)
                {
                    treeObj.AddComponent<Rigidbody>();
                    for (int i = 0; i < treeObjects.Length; i++)
                    {
                        treeObjects[i].transform.parent = treeObj.transform;
                        treeObjects[i].SetActive(true);
                    }
                    Destroy(treeObj);
                }
            }
        }
	}
}
