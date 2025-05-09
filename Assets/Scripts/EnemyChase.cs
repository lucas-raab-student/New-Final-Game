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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            agent.SetDestination(player.position);

        }
        else
        {
            isChasing = false;
        }
    }
}