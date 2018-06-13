using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovementTest : MonoBehaviour 
{
    [SerializeField]private float m_Speed;
    private GameObject target;
    private NavMeshAgent agent;
    public Animator anim;

	void Start () 
    {
        anim = GetComponent<Animator>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
	}
	
	void Update () 
    {
        agent.destination = target.transform.position;
        anim.SetBool("Walking", true);
	}
}
