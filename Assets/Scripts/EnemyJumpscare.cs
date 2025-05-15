using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyJumpscare : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 3f;
    public GameObject jumpscareImage;
    public AudioSource jumpscareSound;
    public float displayTime = 1.5f;
    private bool hasTriggered = false;

    void Update()
    {
        if (!hasTriggered && Vector3.Distance(transform.position, player.position) <= triggerDistance)
        {
            hasTriggered = true;
            StartCoroutine(TriggerJumpscare());
        }
    }

    private IEnumerator TriggerJumpscare()
    {
        jumpscareImage.SetActive(true);
        jumpscareSound.Play();

        // Optional: disable player movement here
        if (player.TryGetComponent(out MonoBehaviour controller))
            controller.enabled = false;

        yield return new WaitForSeconds(displayTime);

        // Load Main Menu (by name or index)
        //SceneManager.LoadScene("MainMenu");  // Or use SceneManager.LoadScene(0);
    }
}
