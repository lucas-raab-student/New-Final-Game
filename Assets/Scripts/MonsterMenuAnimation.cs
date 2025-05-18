using UnityEngine;

public class MonsterMenuAnimation : MonoBehaviour
{
    public Animator monsterAnimator;

    void Start()
    {
        if (monsterAnimator != null)
        {
            // Set the trigger or bool to enter the main menu animation
            monsterAnimator.SetBool("InMainMenu", true);
            // Alternatively, use this if you set up a trigger
            // monsterAnimator.SetTrigger("MainMenuTrigger");
        }
    }
}
