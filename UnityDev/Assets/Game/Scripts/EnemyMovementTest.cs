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

    //Reset
    private float m_ResetSpeed;
    private int m_ResetAnimID;
    private bool m_IsWalking;

	void Start () 
    {
        anim = GetComponent<Animator>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        int setWalkingState = Random.Range(0, 2);
        if (m_ResetAnimID == 0)
        {
            m_Speed = Random.Range(1,5);
            m_ResetSpeed = m_Speed;
            anim.SetBool("IsWalking", true);
            anim.SetTrigger("Walking");
            m_ResetAnimID = Random.RandomRange(1,4);
            anim.SetInteger("WalkingState", m_ResetAnimID);
            m_IsWalking = true;
        }
        else
        {
            m_Speed = Random.Range(5,8);
            m_ResetSpeed = m_Speed;
            anim.SetBool("IsRunning", true);
            anim.SetTrigger("Running");
            m_ResetAnimID = Random.RandomRange(1, 3);
            anim.SetInteger("RunningState", m_ResetAnimID);
        }
	}
	
	void Update () 
    {
        //anim.SetBool("DoAFlip", true);
        if (!setDead)
        {
            agent.destination = target.transform.position;

            agent.speed = m_Speed;
            if (dead)
            {
                agent.velocity.Normalize();
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
                anim.SetInteger("DyingState", Random.Range(1, 11));
                anim.SetTrigger("Dead");
                setDead = true;
            }

            if(anim.GetBool("IsAttacking"))
            {
                Vector3 lookPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                this.gameObject.transform.LookAt(lookPoint);
                
                target.gameObject.GetComponent<PlayerController>().DoDamage(10);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.name == "Player")
        {
            agent.velocity.Normalize();
            anim.SetInteger("AttackingState", Random.Range(1, 3));
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsAttacking", true);
            anim.SetTrigger("Attacking");
            m_Speed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform.name == "Player")
        {
            anim.SetBool("IsAttacking", false);
            m_Speed = m_ResetSpeed;

            if (m_IsWalking)
            {
                anim.SetBool("IsWalking", true);
                anim.SetTrigger("Walking");
                anim.SetInteger("WalkingState", m_ResetAnimID);
            }
            else
            {
                anim.SetBool("IsRunning", true);
                anim.SetTrigger("Running");
                anim.SetInteger("RunningState", m_ResetAnimID);
            }

        }
    }
}
