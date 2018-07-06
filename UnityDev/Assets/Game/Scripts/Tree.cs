using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour 
{
    [SerializeField]private GameObject treeObj;
    [SerializeField]private GameObject[] treeObjects;
    [SerializeField]private float treeHealth;
    private float timer;
    private bool cutDown;
    private bool end;

	void Start () 
    {
        timer = 2;
	}
	
	void Update () 
    {
        if (treeHealth <= 0)
        {
            timer -= 1 * Time.deltaTime;
            cutDown = true;
        }
        if(cutDown && !end)
        {
            if (treeObj != null)
            {
                if (treeObj.GetComponent<Rigidbody>() == null)
                {
                    treeObj.AddComponent<Rigidbody>();
                }
            }
            if (timer <= 0)
            {
                for (int i = 0; i < treeObjects.Length; i++)
                {
                    treeObjects[i].transform.parent = this.gameObject.transform;
                    treeObjects[i].SetActive(true);
                }
                Destroy(treeObj);
                end = true;
            }
        }
	}

    public void DoDamage(float amount)
    {
        treeHealth -= amount;
    }
}
