using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject PickupEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

            // Inform the GameManager that a collectible was picked up
            GameManager.Instance.Collect();

            // Destroy the collectible object
            Destroy(gameObject);
        }
    }
}
