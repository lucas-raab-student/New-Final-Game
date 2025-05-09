using UnityEngine;

public class EnemyInstantKill : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (!other.CompareTag("Player")) return; // Only trigger on player

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            if (animator != null)
            {
                animator.SetTrigger("Hit");
            }

            playerHealth.TakeDamage(0);
        }
    }

}
