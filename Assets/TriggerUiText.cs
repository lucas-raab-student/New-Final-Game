using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI Text

public class TriggerUiText : MonoBehaviour
{
    public Text messageText; //asing the ui insepctor
    public string message;
    public string triggerTag = "Player";
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag) && messageText != null)
        { 
            messageText.text = message;
            messageText.gameObject.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(triggerTag) && messageText.text!=null)
        {
            messageText.gameObject.SetActive(false);
        }
    }
}

