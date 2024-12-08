/*
 * Code Artifact Name: MainMenu
 * Description: Manages main menu navigation, including starting the game, accessing settings, and exiting the application.
 * Programmer's Name: [Your Name]
 * Date Created: [Original creation date]
 * Revision History:
 *   - [Date 1]: Initial creation of the script by [Author's Name].
 * Preconditions:
 *   - All referenced scenes (e.g., DifficultyMenu, SettingsMenu) must be added to the Unity Build Settings.
 * Acceptable Input Values:
 *   - Valid scene names corresponding to the Unity project scenes.
 * Unacceptable Input Values:
 *   - Null or incorrectly named scene references.
 * Postconditions:
 *   - Scene transitions occur based on the selected menu option.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - SceneNotFoundException if the scene name is invalid.
 * Side Effects:
 *   - Logs debugging messages and changes the active scene.
 * Invariants:
 *   - The MainMenu script must remain active in the main menu scene.
 * Known Faults:
 *   - Does not validate the existence of scenes before attempting to load them.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Starts the game by navigating to the DifficultyMenu scene.
    public void PlayGame()
    {
        // Uncommented alternative for next-scene navigation:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SceneManager.LoadScene("DifficultyMenu"); // Load the DifficultyMenu scene.
    }

    // Navigates to the SettingsMenu scene.
    public void goToSettings()
    {
        SceneManager.LoadScene("SettingsMenu"); // Load the SettingsMenu scene.
    }

    // Navigates to the DifficultyMenu scene.
    public void goToDifficulty()
    {
        SceneManager.LoadScene("DifficultyMenu"); // Load the DifficultyMenu scene.
    }

    // Quits the game application.
    public void QuitGame()
    {
        Debug.Log("Quit"); // Log the quit action for debugging purposes.
        Application.Quit(); // Close the application.
    }
}
