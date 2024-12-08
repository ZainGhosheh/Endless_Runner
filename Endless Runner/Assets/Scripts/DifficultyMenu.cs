/*
 * Code Artifact Name: DifficultyMenu
 * Description: Handles scene transitions based on difficulty level selection.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 12/01/24
 * Revision History:
 *   - 12/01/24: Initial creation of the script by Zain Ghosheh.
 * Preconditions:
 *   - Difficulty scenes (Easy, Medium, Hard) must be added to the Unity Build Settings.
 * Acceptable Input Values:
 *   - Scene names must correspond to valid scenes.
 * Unacceptable Input Values:
 *   - Invalid or missing scene names.
 * Postconditions:
 *   - Loads the selected difficulty scene.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - SceneNotFoundException if the scene name is invalid.
 * Side Effects:
 *   - Changes the active scene.
 * Invariants:
 *   - The scene name must always be valid.
 * Known Faults:
 *   - None.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    public void Easy()
    {
        SceneManager.LoadScene("Easy"); // Load the "Easy" difficulty scene.
    }

    public void Medium()
    {
        SceneManager.LoadScene("Medium"); // Load the "Medium" difficulty scene.
    }

    public void Hard()
    {
        Debug.Log("Hard"); // Log the selected difficulty for debugging.
        SceneManager.LoadScene("Hard"); // Load the "Hard" difficulty scene.
    }
}
