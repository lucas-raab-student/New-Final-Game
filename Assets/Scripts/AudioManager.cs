using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton instance for easy access
    public AudioClip collectiblesoundClip; // Audio clip to play for collection sound
    private AudioSource audioSource; // Cached reference to the AudioSource

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make sure AudioManager survives scene changes
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this one
        }

        audioSource = GetComponent<AudioSource>(); // Cache the AudioSource component
    }

    // Method to play the collection sound
    public void PlayCollectSound()
    {
        if (audioSource != null && collectiblesoundClip != null)
        {
            // Set the start time for the clip
            audioSource.time = 1f; // Set this to the time where you want the sound to start

            // Assign the clip to the AudioSource and play it from the set time
            audioSource.clip = collectiblesoundClip;
            audioSource.Play(); // Play the audio from the specified time
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not set in AudioManager.");
        }
    }
}
