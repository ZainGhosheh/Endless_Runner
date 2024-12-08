/*
 * Code Artifact Name: Enemies
 * Description: Manages enemy health, handles damage, and triggers destruction upon death.
 * Programmer's Name: [Your Name]
 * Date Created: [Original creation date]
 * Revision History:
 *   - [Date 1]: Initial creation of the script by [Author's Name].
 * Preconditions:
 *   - Enemy GameObject must have a Collider2D and be set on a valid layer.
 *   - maxHealth should be set to a positive integer.
 * Acceptable Input Values:
 *   - Damage values passed to TakeDamage must be non-negative.
 * Unacceptable Input Values:
 *   - Negative damage values or null references to the GameObject.
 * Postconditions:
 *   - Enemy health is reduced by the damage value.
 *   - Enemy GameObject is destroyed upon reaching 0 health.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - None.
 * Side Effects:
 *   - Logs death messages and removes the GameObject from the scene.
 * Invariants:
 *   - Enemy health must remain between 0 and maxHealth.
 * Known Faults:
 *   - Does not account for invulnerability or healing mechanics.
 */

using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy.
    int currentHealth; // Tracks the enemy's current health.

    // Called when the script instance is loaded.
    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health.
    }

    // Reduces the enemy's health by the damage value.
    // If health reaches 0, triggers the Die method.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Subtract the damage value from current health.

        // Check if the enemy's health has reached zero.
        if (currentHealth == 0)
        {
            Die(); // Trigger the death behavior.
        }
    }

    // Handles the enemy's death, including destruction and cleanup.
    void Die()
    {
        Debug.Log("Enemy died!"); // Log a message indicating the enemy's death.
        Destroy(gameObject); // Remove the enemy GameObject from the scene.
        this.enabled = false; // Disable this script to prevent further behavior.
    }
}
