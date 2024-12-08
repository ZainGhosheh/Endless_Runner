/*
 * Code Artifact Name: UIManager
 * Description: Manages the game's UI elements, including score display, game over screen, and scene navigation.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 10/25/24
 * Revision History:
 *   - 10/25/24: Initial creation of the script by Zain Ghosheh.
 * Preconditions:
 *   - TextMeshProUGUI and GameObject references must be assigned in the Unity Inspector.
 *   - GameManager must be implemented and properly configured.
 * Acceptable Input Values:
 *   - Valid GameManager instance with onGameOver and PrettyScore methods implemented.
 * Unacceptable Input Values:
 *   - Null references for GameManager or UI elements.
 * Postconditions:
 *   - Updates UI elements dynamically based on game state.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - NullReferenceException if required references are not assigned.
 * Side Effects:
 *   - Activates or deactivates GameObjects and modifies TextMeshPro text.
 * Invariants:
 *   - GameManager instance must always exist during gameplay.
 * Known Faults:
 *   - Does not account for null values in TextMeshPro or GameManager methods.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI; // Displays the current score.
    [SerializeField] private GameObject gameObjectUI; // Game Over UI panel.
    [SerializeField] private TextMeshProUGUI gameOverScoreUI; // Final score on Game Over screen.
    [SerializeField] private TextMeshProUGUI gameOverHighscoreUI; // High score on Game Over screen.

    private GameManager gm; // Reference to the GameManager instance.

    private void Start()
    {
        gm = GameManager.Instance; // Retrieve the GameManager instance.
        gm.onGameOver.AddListener(ActivateGameOverUI); // Add a listener to show Game Over UI.
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Navigate to the Main Menu scene.
    }

    public void PlayButtonHandler()
    {
        gm.StartGame(); // Call GameManager's StartGame method to begin the game.
    }

    public void ActivateGameOverUI()
    {
        gameObjectUI.SetActive(true); // Show the Game Over UI panel.
        gameOverScoreUI.text = "Score: " + gm.PrettyScore(); // Display the player's final score.
        gameOverHighscoreUI.text = "Highscore: " + gm.PrettyhighScore(); // Display the player's high score.
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore(); // Update the score display during gameplay.
    }

    public void CopyScoreToClipboard()
    {
        GUIUtility.systemCopyBuffer = "Score: " + gm.PrettyCopyScore(); // Copy the score to the clipboard.
    }
}
