using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    // Method to toggle the active state of the GameObject
    public void ToggleActiveState()
    {
        gameObject.SetActive(!gameObject.activeSelf); // Toggle the active state
    }
}
