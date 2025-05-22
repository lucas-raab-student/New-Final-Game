using UnityEngine;
using UnityEngine.SceneManagement;

public class Endingtrigger : MonoBehaviour
{    public string triggerTag = "Player";

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            SceneManager.LoadScene("Thank You");
        }
    }
}
