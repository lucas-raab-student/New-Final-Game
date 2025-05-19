using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject PickupEffect;  // Pickup effect (e.g., particle system)

    // This method is called when the player collects the item
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the collection sound
            AudioManager.Instance.PlayCollectSound();

            // Play the pickup effect if assigned
            if (PickupEffect)
            {
                Instantiate(PickupEffect, transform.position, Quaternion.identity);
            }

            // Notify the CollectibleManager that this collectible was picked up
            CollectibleManager.Instance.CollectItem();

            // Destroy this collectible object
            Destroy(gameObject);
        }
    }
}
