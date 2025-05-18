using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterStartupAnimation : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Main Menu")
        {
            animator.Play("idle1");
        }
        else
        {
            animator.Play("walk2"); // or whatever the movement state is
        }
    }
}
