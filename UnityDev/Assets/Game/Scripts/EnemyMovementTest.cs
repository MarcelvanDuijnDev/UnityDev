using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovementTest : MonoBehaviour 
{
    [SerializeField]private float m_Speed;
    private GameObject target;
    private NavMeshAgent agent;


	void Start () 
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
	}
	
	void Update () 
    {
        agent.destination = target.transform.position;
	}
}
