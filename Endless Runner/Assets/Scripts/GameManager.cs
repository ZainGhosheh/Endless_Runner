/*
 * Code Artifact Name: GameManager
 * Description: Central controller for managing game states, scores, and events such as game over.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 11/09/24
 * Revision History:
 *   - 11/09/24: Initial creation of the script by Olufewa Alonge.
 * Preconditions:
 *   - GameManager must be assigned to a GameObject in the Unity scene.
 * Acceptable Input Values:
 *   - Valid calls to GameManager methods like StartGame and gameOver.
 * Unacceptable Input Values:
 *   - Null references to data or required event listeners.
 * Postconditions:
 *   - Updates game states (playing, game over) and manages scores.
 * Return Values:
 *   - String representations of scores for UI display.
 * Error and Exception Conditions:
 *   - None.
 * Side Effects:
 *   - Invokes UnityEvents for other scripts to respond to state changes.
 * Invariants:
 *   - GameManager instance must exist as a singleton during runtime.
 * Known Faults:
 *   - Does not handle corrupted save files or invalid high scores.
 */

using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance of GameManager.

    public float currentScore; // Tracks the current game score.
    public float copyScore; // Stores the final score at game over.
    public Data data; // Reference to a Data object for saving high scores.
    public bool isPlaying = false; // Tracks whether the game is currently active.

    public UnityEvent onPlay = new UnityEvent(); // Event triggered when the game starts.
    public UnityEvent onGameOver = new UnityEvent(); // Event triggered when the game ends.

    public void Awake()
    {
        // Ensure only one instance of GameManager exists.
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Play background music and initialize scores.
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
        string loadedData = SaveSystem.Load("save");
        currentScore = 0f;

        if (loadedData != null)
        {
            data = JsonUtility.FromJson<Data>(loadedData); // Load saved data.
        }
        else
        {
            data = new Data(); // Create a new Data object if no save exists.
        }
    }

    private void Update()
    {
        isPlaying = GameObject.Find("Player") != null; // Check if the player exists.

        if (isPlaying)
        {
            currentScore += Time.deltaTime; // Increment the score over time.
        }
        else
        {
            currentScore = 0f; // Reset the score if the player is absent.
        }
    }

    public void StartGame()
    {
        onPlay.Invoke(); // Trigger onPlay event.
        isPlaying = true; // Set the game state to active.
        currentScore = 0f; // Reset the score.
    }

    public void gameOver()
    {
        copyScore = currentScore; // Store the final score.

        if (data.highScore < currentScore)
        {
            data.highScore = currentScore; // Update the high score if necessary.
            string saveString = JsonUtility.ToJson(data);
            SaveSystem.Save("save", saveString); // Save the updated high score.
        }

        isPlaying = false; // Set the game state to inactive.
        onGameOver.Invoke(); // Trigger onGameOver event.
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString(); // Return the rounded current score.
    }

    public string PrettyhighScore()
    {
        return Mathf.RoundToInt(data.highScore).ToString(); // Return the rounded high score.
    }

    public string PrettyCopyScore()
    {
        return Mathf.RoundToInt(copyScore).ToString(); // Return the rounded final score.
    }
}
