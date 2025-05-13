using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject jumpscareImage;
    [SerializeField] private AudioSource screamAudio;
    public void TakeDamage(int damage)
    {
        Die();
    }

    void Die()
    {
    
    }
    void ShowJumpScare()
    {
        jumpscareImage.SetActive(true);
        screamAudio.Play();
        StartCoroutine(PauseAfterDelay(2f));
    }
    IEnumerator PauseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0; // freezes game
    }
}

