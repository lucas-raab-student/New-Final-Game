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
        jumpscareSound.time=1f;
        jumpscareSound.Play();

        FirstPersonCamera movement = player.GetComponent<FirstPersonCamera>();
        if (movement != null)
        {
            movement.enabled = false;
        }

        yield return new WaitForSeconds(displayTime);

        // Load main menu
        SceneManager.LoadScene("Death Game");
    }
}
