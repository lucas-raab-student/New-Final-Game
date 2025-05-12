using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float waitTimeAtPoint = 2f; // Optional wait time
    private float waitTimer;

    private bool waiting = false;
    private float distanceThreshold = 0.5f;

    public LayerMask navMeshLayerMask = NavMesh.AllAreas;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component missing!");
            enabled = false;
            return;
        }

        MoveToNewPoint(); // Start with first point
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= distanceThreshold)
        {
            if (!waiting)
            {
                waiting = true;
                waitTimer = waitTimeAtPoint;
            }

            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0f)
            {
                waiting = false;
                MoveToNewPoint();
            }
        }
    }

    void MoveToNewPoint()
    {
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, navMeshLayerMask);
        agent.SetDestination(newPos);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layerMask)
    {
        Vector3 randDirection = Random.insideUnitSphere * distance + origin;
        randDirection.y = origin.y; // Keep movement on same height
        NavMeshHit navHit;

        if (NavMesh.SamplePosition(randDirection, out navHit, distance, layerMask))
            return navHit.position;

        return origin;
    }
}
