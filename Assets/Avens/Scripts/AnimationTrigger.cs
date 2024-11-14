using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component from the GameObject this script is attached to
        animator = GetComponent<Animator>();
    }

    // Method to call to start the animation
    public void TriggerAnimation(string triggerName)
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
        else
        {
            Debug.LogWarning("Animator component not found on this GameObject.");
        }
    }
}
