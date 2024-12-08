/*
 * Code Artifact Name: PlayerCollision
 * Description: Handles player collision events and triggers Game Over logic when hitting obstacles.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 11/21/24
 * Revision History:
 *   - 11/21/24: Initial creation of the script by Zain Ghosheh.
 * Preconditions:
 *   - GameManager must be implemented and configured.
 *   - Player GameObject must have a Collider2D component.
 * Acceptable Input Values:
 *   - Collisions with objects tagged as "Obstacle" or "Enemy".
 * Unacceptable Input Values:
 *   - Collisions with objects not tagged appropriately.
 * Postconditions:
 *   - Player GameObject is deactivated.
 *   - GameManager's gameOver logic is triggered.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - None.
 * Side Effects:
 *   - Deactivates the player GameObject.
 * Invariants:
 *   - Player must be active until a collision occurs.
 * Known Faults:
 *   - Does not handle invulnerable states or shields.
 */

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.onPlay.AddListener(ActivatePlayer); // Ensure the player is active when the game starts.
    }

    private void ActivatePlayer()
    {
        gameObject.SetActive(true); // Enable the player GameObject.
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collision is with an "Obstacle" or "Enemy".
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false); // Deactivate the player GameObject.
            GameManager.Instance.gameOver(); // Trigger Game Over logic in the GameManager.
        }
    }
}
