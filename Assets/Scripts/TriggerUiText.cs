using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TriggerUiText : MonoBehaviour
{
    public Text messageText; // Assign this in the Inspector
    public string message;
    public string triggerTag = "Player";
    public float fadeDuration = 1f;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        if (messageText == null)
        {
            Debug.LogError("Message Text is not assigned in the Inspector.");
            return;
        }

        // Always get the CanvasGroup from the same GameObject as the messageText
        canvasGroup = messageText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = messageText.gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0f;
        messageText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
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
        if (other.CompareTag(triggerTag) && canvasGroup != null)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup is null in FadeIn()");
            yield break;
        }

        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }

    private IEnumerator FadeOut()
    {
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup is null in FadeOut()");
            yield break;
        }

        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
        messageText.gameObject.SetActive(false);
    }
}
