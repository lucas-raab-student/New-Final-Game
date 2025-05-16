using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public  int CollectiblesCollected;
    public int totalCollectibles;
    public GameObject door;
    public Text collectibleText; // Reference to the UI text
public AudioSource Collectiblesound;
    void Awake()
        {
            // If there's already an instance, destroy this one
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);  // This destroys the new instance to keep only one GameManager
            }
            else
            {
                Instance = this;  // Assign this GameManager instance to the static Instance variable
                DontDestroyOnLoad(gameObject);  // Make sure this GameManager persists across scenes
            }
        }

    

    static public void LoadScene(string newsceneName)
    {
        SceneManager.LoadScene(newsceneName);
    }
    static public void Quit()
    {
        Application.Quit();
    }
    public void Collect()
    {
        CollectiblesCollected++;
        Collectiblesound.time = 0.8f; 
       Collectiblesound.Play();
        Debug.Log($"Collected: {CollectiblesCollected}/{totalCollectibles}");

        if (CollectiblesCollected == totalCollectibles)
        {

          
                ShowDoor();
            
        }
        // Update UI text
        if (collectibleText != null)
        {

            collectibleText.text = $"Collected: {CollectiblesCollected} / {totalCollectibles}";

        }
    }
    void ShowDoor()
    {
        // Make the door visible (or active)
        if (door != null)
        {
            door.SetActive(true); // Shows the door if it was hidden
            Debug.Log("✅ Door set active!");

        }

        // Optional: Play a sound or show a message here
        Debug.Log("The door has appeared!");

        // Call the win game function (if you want to load a new scene after this)
        //WinGame();
    }
    //void WinGame()
    //{
        /// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       /// Debug.Log("You win");
        // Trigger win condition here
   // }

}


