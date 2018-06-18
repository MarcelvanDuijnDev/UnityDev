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
        anim.SetTrigger("Walking");
        anim.SetInteger("WalkingState", 1);
	}
	
	void Update () 
    {
        agent.destination = target.transform.position;
	}
}
