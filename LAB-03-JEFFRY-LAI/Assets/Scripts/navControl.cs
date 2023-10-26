using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{
    public GameObject TargetAttack;
    private NavMeshAgent agent;

    bool isWalking = true;
    Animator animator;

    [field: Header("Speed Control")]
    [field: Range(0, 10)]

    [field: SerializeField] float animationSpeed = 1f;
    [field: Range(0, 10)]

    [field: SerializeField] float navMeshAgentSpeed = 1f;
    [field: Range(0, 10)]

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = animationSpeed;
        agent.speed = navMeshAgentSpeed;

        if (isWalking)
        {
            agent.destination = TargetAttack.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
