using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialtriggerss : MonoBehaviour
{
    public GameObject[] ObjectToActivate;
    public string triggertag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrEmpty(triggertag) || other.CompareTag(triggertag))
        {
            Debug.Log("Player ENTERED the zone");
            foreach (GameObject obj in ObjectToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (string.IsNullOrEmpty(triggertag) || other.CompareTag(triggertag))
        {
            Debug.Log("Player EXITED the zone");
            foreach (GameObject obj in ObjectToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
