/*
 * Code Artifact Name: PlayerCombat
 * Description: Manages the player's combat actions, including attacking enemies within a specified range.
 * Programmer's Name: [Your Name]
 * Date Created: [Original creation date]
 * Revision History:
 *   - [Date 1]: Initial creation of the script by [Author's Name].
 * Preconditions:
 *   - AttackPoint must be set in the Unity Inspector.
 *   - Enemy layers must be configured to include valid enemy GameObjects.
 * Acceptable Input Values:
 *   - Input key for attacking ("Space") must be mapped in the Unity Input Manager.
 *   - AttackPoint must be within the attackable range of enemies.
 * Unacceptable Input Values:
 *   - Null references for AttackPoint or enemyLayers.
 * Postconditions:
 *   - Enemies within attack range are damaged or destroyed.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - NullReferenceException if AttackPoint is not assigned.
 * Side Effects:
 *   - Removes enemy GameObjects from the scene.
 * Invariants:
 *   - Attack range remains constant during gameplay.
 * Known Faults:
 *   - Does not account for invulnerable or shielded enemies.
 */

using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator; // Animator component controlling player animations.
    public Transform attackPoint; // The position from where attack range is calculated.
    public LayerMask enemyLayers; // Specifies the layers to detect enemies.
    public float attackRange = 0.5f; // Radius of the attack range.
    public int attackDamage = 100; // Damage dealt to enemies when attacking.

    // Update is called once per frame.
    void Update()
    {
        // Check if the player presses the attack button ("Space").
        if (Input.GetButtonDown("Space")) 
        {
            Debug.Log("Attack Button Pressed"); // Log for debugging purposes.
            Attack(); // Call the Attack function to handle the attack logic.
        }
    }

    // Handles the attack logic, including detecting enemies and dealing damage.
    public void Attack()
    {
        animator.SetTrigger("Attack"); // Trigger the attack animation in the Animator.

        // Detect all colliders within the attack range that match the enemy layers.
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Loop through each detected enemy collider.
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name); // Log the name of the hit enemy for debugging.
            Destroy(enemy.gameObject); // Remove the enemy GameObject from the scene.
        }
    }

    // Visualizes the attack range in the Unity Editor for debugging purposes.
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) // Ensure AttackPoint is not null.
            return; // Exit if no attack point is assigned.

        // Draw a wireframe sphere at the attack point to indicate the attack range.
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
