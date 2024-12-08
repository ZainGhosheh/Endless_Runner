/*
 * Code Artifact Name: SettingsMenu
 * Description: Manages the game's settings, including volume control and navigation to the main menu.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 11/19/24
 * Revision History:
 *   - 11/19/24: Initial creation of the script by Mahgoub Husein.
 * Preconditions:
 *   - AudioMixer must be configured and assigned in the Unity Inspector.
 * Acceptable Input Values:
 *   - Volume must be a float within the range supported by the AudioMixer.
 * Unacceptable Input Values:
 *   - Invalid or null references to scenes or AudioMixer.
 * Postconditions:
 *   - Volume changes persist in real-time.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - None.
 * Side Effects:
 *   - Adjusts the game's audio settings.
 * Invariants:
 *   - Volume changes are applied immediately when adjusted.
 * Known Faults:
 *   - Does not validate scene names or AudioMixer parameter keys.
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to the AudioMixer controlling game audio.

    // Navigates to the Main Menu scene
    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Loads the "MainMenu" scene.
    }

    // Adjusts the game's audio volume
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); // Updates the volume parameter in the AudioMixer.
    }
}
