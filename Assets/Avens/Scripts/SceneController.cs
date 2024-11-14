using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Reference to the GameObjects to enable and disable
    public GameObject objectToDisable;
    public GameObject objectToEnable;
    public GameObject confirmExitWindow; // GameObject for the exit confirmation dialog

    // Method to change to a specified scene by index with delay
    public void ChangeScene(int sceneIndex)
    {
        StartCoroutine(ChangeSceneRoutine(sceneIndex));
    }

    // Coroutine to handle the scene change with delay
    IEnumerator ChangeSceneRoutine(int sceneIndex)
    {
        // Disable and enable GameObjects
        if (objectToDisable != null)
            objectToDisable.SetActive(false);
        if (objectToEnable != null)
            objectToEnable.SetActive(true);

        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        // Load the new scene
        SceneManager.LoadScene(sceneIndex);
    }

    // Method to reload the current scene
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Method to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    // Method to display exit confirmation window
    public void ShowExitConfirmation()
    {
        if (objectToDisable != null)
            objectToDisable.SetActive(false);
        if (confirmExitWindow != null)
            confirmExitWindow.SetActive(true);
    }

    // Method to close exit confirmation window
    public void CloseExitConfirmation()
    {
        if (objectToDisable != null)
            objectToDisable.SetActive(true);
        if (confirmExitWindow != null)
            confirmExitWindow.SetActive(false);
    }
}
