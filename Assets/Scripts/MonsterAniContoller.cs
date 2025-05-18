using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAniContoller : MonoBehaviour
{
public Animator animator;
    private NavMeshAgent agent; // Remove if not using NavMesh

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        agent = GetComponent<NavMeshAgent>(); // Comment this out if not using NavMesh
    }

    void Update()
    {
        // Use NavMeshAgent velocity to detect movement
        float speed = agent.velocity.magnitude; // Comment this line if not using NavMesh

        // If moving, play walking animation
        animator.SetBool("isWalking", speed > 0.1f);

        // Alternative: Use transform movement if you're not using NavMesh
        // float movement = (transform.position - lastPosition).magnitude / Time.deltaTime;
        // animator.SetBool("isWalking", movement > 0.1f);
        // lastPosition = transform.position;
    }
}
