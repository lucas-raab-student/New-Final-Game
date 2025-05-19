using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    public int CollectiblesCollected;
    public int totalCollectibles;
    public GameObject door;
    public Text collectibleText; // UI text to show collection progress

    private void Awake()
    {
        // Ensuring only one instance of CollectibleManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectItem()
    {
        CollectiblesCollected++;

        // Update UI text
        if (collectibleText != null)
        {
            collectibleText.text = $"Collected: {CollectiblesCollected} / {totalCollectibles}";
        }

        Debug.Log($"Collected: {CollectiblesCollected}/{totalCollectibles}");

        if (CollectiblesCollected == totalCollectibles)
        {
            ShowDoor();
        }
    }

    void ShowDoor()
    {
        // Make the door visible (or active)
        if (door != null)
        {
            door.SetActive(true);
        }

        Debug.Log("The door has appeared!");

        // Optional: Trigger any win condition logic (e.g., load next scene)
    }
}
