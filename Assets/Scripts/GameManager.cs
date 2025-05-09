using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance)
        {
            Destroy(this);


        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
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
