using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // For UI Text

public class TriggerUiText : MonoBehaviour
{
    public Text messageText; //asing the ui insepctor
    public string message;
    public string triggerTag = "Player";
    public float fadeDuration = 1f;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        // get the canavas groupm]  compnent 
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null )
        {
            canvasGroup=messageText.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f;
        messageText.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag) && messageText != null)
        { 
            messageText.text = message;
            messageText.gameObject.SetActive(true);
            StartCoroutine(FadeIn());

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(triggerTag) && canvasGroup!=null)
        {
            StartCoroutine(FadeOut());

        }
    }
    private IEnumerator FadeIn()
    {
        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f; // Ensure fully visible at the end
    }

    // Fade-out transition
    private IEnumerator FadeOut()
    {
        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f; // Ensure fully invisible at the end
        messageText.gameObject.SetActive(false); // Optionally hide message after fade
    }
}


