using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    public float speedThreshold = 0.1f;

    private NavMeshAgent agent;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 velocity = agent != null ? agent.velocity : Vector3.zero;

        bool isRunning = velocity.magnitude > speedThreshold;

        animator.SetBool("isRunning", isRunning);
    }
}
