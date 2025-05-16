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
            if (door != null)
            {
                door.SetActive(true); // Make door visible/interactable
                Debug.Log("The door has appeared!");
            }
        }



    
 

}


