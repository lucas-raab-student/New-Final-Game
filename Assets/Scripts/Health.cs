using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        Die();
    }

    void Die()
    {
        Debug.Log("Player died instantly!");
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in editor

#endif
    }
}

