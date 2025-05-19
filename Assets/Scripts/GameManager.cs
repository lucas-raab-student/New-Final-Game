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
   

}


