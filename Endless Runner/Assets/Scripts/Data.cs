/*
 * Code Artifact Name: Data
 * Description: A serializable class to store and manage player data, such as high scores.
 * Programmer's Name: [Your Name]
 * Date Created: [Original creation date]
 * Revision History:
 *   - [Date 1]: Initial creation of the script by [Author's Name].
 * Preconditions:
 *   - The class must be marked as [System.Serializable] to enable JSON serialization and deserialization.
 * Acceptable Input Values:
 *   - Valid floating-point values for highScore (non-negative numbers recommended).
 * Unacceptable Input Values:
 *   - Negative or invalid floating-point values.
 * Postconditions:
 *   - High score data is stored in an accessible format for saving and loading.
 * Return Values:
 *   - None (fields directly accessible).
 * Error and Exception Conditions:
 *   - None.
 * Side Effects:
 *   - Data is serialized or deserialized when saving or loading from external sources.
 * Invariants:
 *   - highScore must represent the player's highest achieved score.
 * Known Faults:
 *   - Does not include methods for validating or processing highScore.
 */

using UnityEngine;

// Marks the class as serializable for JSON or other serialization frameworks.
[System.Serializable]
public class Data
{
    public float highScore; // Stores the player's highest achieved score.

    // Note: This class is a simple data container, so no additional methods are defined.
}
