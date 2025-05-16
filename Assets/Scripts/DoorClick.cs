using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorClick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (GameManager.Instance.CollectiblesCollected == GameManager.Instance.totalCollectibles)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Door clciked next scene");

        }
        else
        {
            Debug.Log("Not enough ");
        }
    }
}
