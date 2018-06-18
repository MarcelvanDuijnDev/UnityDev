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
    [HideInInspector]
    public bool dead;
    private bool setDead;

	void Start () 
    {
        anim = GetComponent<Animator>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        int setWalkingState = Random.Range(0, 2);
        Debug.Log(setWalkingState);
        anim.SetInteger("DyingState", Random.Range(1, 11));
        if (setWalkingState == 0)
        {
            m_Speed = Random.Range(2,5);
            anim.SetBool("IsWalking", true);
            anim.SetTrigger("Walking");
            anim.SetInteger("WalkingState", Random.Range(1, 4));
        }
        else
        {
            m_Speed = Random.Range(6,10);
            anim.SetBool("IsRunning", true);
            anim.SetTrigger("Running");
            anim.SetInteger("RunningState", Random.Range(1, 3));
        }
	}
	
	void Update () 
    {
        if (!setDead)
        {
            agent.destination = target.transform.position;

            agent.speed = m_Speed;
            if (dead)
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
                anim.SetTrigger("Dead");
                setDead = true;
            }
        }
    }
}
