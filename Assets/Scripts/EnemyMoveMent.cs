
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveMent : MonoBehaviour
{
    private NavMeshAgent agent;
    public float wanderRaduis = 10f;
    public float wanderTimer = 5f;
    public float timer;
   
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > wanderTimer )
        {
            Vector3 newPos=RandomNavSphere(transform.position,wanderRaduis,-1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layerMask )
    {
        Vector3 randDirection = Random.insideUnitSphere*distance;
        randDirection += origin;
        NavMeshHit navhit;
        NavMesh.SamplePosition(randDirection, out navhit,distance,layerMask);
        return navhit.position;
    }
}
