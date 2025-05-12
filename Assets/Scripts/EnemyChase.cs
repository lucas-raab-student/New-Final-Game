using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float stopChasingDistance = 15f;
    private NavMeshAgent agent;
    public bool isChasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
{
    float distanceToPlayer = Vector3.Distance(transform.position, player.position);

    if (isChasing)
    {
        if (distanceToPlayer > stopChasingDistance)
        {
            isChasing = false;
            agent.ResetPath();
        }
        else
        {
            agent.SetDestination(player.position);
        }
    }
    else
    {
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            agent.SetDestination(player.position);
        }
    }
}

    }
}
