/*
 * Code Artifact Name: PauseMenu
 * Description: Manages the game's pause functionality, including resuming and navigating back to the main menu.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 11/13/24
 * Revision History:
 *   - 11/13/24: Initial creation of the script by Zain Ghosheh.
 * Preconditions:
 *   - A UI GameObject for the pause menu must be assigned in the Unity Inspector.
 * Acceptable Input Values:
 *   - Input key for pausing ("Pause") must be mapped in Unity Input Manager.
 * Unacceptable Input Values:
 *   - Null references for the pause menu or input key bindings.
 * Postconditions:
 *   - The game's time scale is adjusted, and the pause menu visibility toggles.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - None.
 * Side Effects:
 *   - Modifies the time scale of the game.
 * Invariants:
 *   - Time scale is 0 while paused and 1 while playing.
 * Known Faults:
 *   - Does not account for complex time-based effects during pause.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the pause menu UI GameObject.
    public static bool isPaused; // Tracks whether the game is currently paused.

    void Start()
    {
        pauseMenu.SetActive(false); // Ensure the pause menu is hidden initially.
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause")) // Check if the pause button is pressed.
        {
            Debug.Log("Pause key pressed"); // Log for debugging purposes.
            if (isPaused)
            {
                ResumeGame(); // Resume the game if it is currently paused.
            }
            else
            {
                PauseGame(); // Pause the game if it is currently playing.
            }
        }
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Navigate to the main menu scene.
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Show the pause menu.
        Time.timeScale = 0f; // Freeze the game's time scale.
        isPaused = true; // Set the pause state to true.
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Hide the pause menu.
        Time.timeScale = 1f; // Resume the game's time scale.
        isPaused = false; // Set the pause state to false.
    }

    public void QuitGame()
    {
        Debug.Log("Quit"); // Log the quit action for debugging purposes.
        Application.Quit(); // Quit the game application.
    }
}
