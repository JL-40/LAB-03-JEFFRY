using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshControl : MonoBehaviour
{
    public GameObject TargetAttack;
    private NavMeshAgent agent;

    bool isWalking = true;
    Animator animator;

    [field: Header("Speed Control")]
    [field: Range(0, 1)]

    [field: SerializeField] float speed = 1f;
    [field: Range(0, 1)]

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = speed;
        agent.speed = speed;

        if (isWalking)
        {
            agent.destination = TargetAttack.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }
    }
}
