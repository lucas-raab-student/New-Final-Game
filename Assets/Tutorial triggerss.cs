using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorialtriggerss : MonoBehaviour
{
    public GameObject[] ObjectToActivate;
    public string triggertag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if(string.IsNullOrEmpty(triggertag)|| other.CompareTag(triggertag))
        {
            Debug.Log("Player has enter zone");
            foreach(GameObject obj in ObjectToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
          
    }
}
