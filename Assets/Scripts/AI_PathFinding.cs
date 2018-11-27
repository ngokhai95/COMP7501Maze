using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_PathFinding : MonoBehaviour
{
    public Transform[] wayPoints;
    public float speed = 1;

    private NavMeshAgent navigate;
    private int destination;
    private Animator anim;

    // Use this for initialization
    void Start ()
    {
        navigate = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        navigate.speed = speed;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (!navigate.pathPending && navigate.remainingDistance < 0.5f)
        {
            Move();
            anim.SetBool("isIdling", false);
            anim.SetTrigger("Walk");
        }
    }

    void Move()
    {
        if (wayPoints.Length == 0)
        {
            return;
        }
        navigate.destination = wayPoints[destination].position;
        destination = (destination + 1) % wayPoints.Length;
    }
}
