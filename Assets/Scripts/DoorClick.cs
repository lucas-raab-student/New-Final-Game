using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorClick : MonoBehaviour
{
    // Reference to the CollectibleManager (for tracking collected items)
    public CollectibleManager collectibleManager;

    // Start is called before the first frame update
    private void Start()
    {
        // Optionally, you can get the CollectibleManager reference if you don't set it in the Inspector
        if (collectibleManager == null)
        {
            collectibleManager = FindObjectOfType<CollectibleManager>();
        }
    }

    private void OnMouseDown()
    {
        // Check if the player has collected all the items
        if (collectibleManager.CollectiblesCollected == collectibleManager.totalCollectibles)
        {
            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Door clicked, loading next scene.");
        }
        else
        {
            Debug.Log("Not enough collectibles!");
        }
    }
}
