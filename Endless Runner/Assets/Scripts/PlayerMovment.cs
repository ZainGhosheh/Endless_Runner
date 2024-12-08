/*
 * Code Artifact Name: PlayerMovement
 * Description: Handles player movement and input for running, jumping, and crouching.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 10/27/24
 * Revision History:
 *   - 10/27/24: Initial creation of the script by Zain Ghosheh.
 * Preconditions:
 *   - The CharacterController2D component must be assigned to the controller variable.
 *   - Audio clips for jump and crouch must be configured in the AudioSource components.
 * Acceptable Input Values:
 *   - Horizontal input must be a valid float between -1 and 1.
 *   - Vertical joystick input must be between -1 and 1.
 * Unacceptable Input Values:
 *   - Null references for controller or AudioSource components.
 * Postconditions:
 *   - The player character moves based on user input.
 *   - Jump and crouch animations are triggered correctly.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - NullReferenceException if required components are not assigned.
 * Side Effects:
 *   - Updates animator parameters for animations.
 * Invariants:
 *   - Player movement speed remains constant during runtime unless explicitly modified.
 * Known Faults:
 *   - Does not account for input changes during complex animation transitions.
 */

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; // Reference to the CharacterController2D script for movement logic.
    public float runSpeed = 40f; // Speed multiplier for horizontal movement.
    public Joystick joystick; // Joystick input for mobile platforms.
    public Animator animator; // Reference to the Animator component for handling animations.

    AudioSource jumpsound; // AudioSource for jump sound effects.
    AudioSource crouchsound; // AudioSource for crouch sound effects.
    float horizontalMove = 0f; // Tracks horizontal input for movement.
    bool jump = false; // Tracks if the player is jumping.
    bool crouch = false; // Tracks if the player is crouching.
    private bool isJumping = false; // Ensures jump logic is not triggered multiple times.

    // Called once per frame to process player input.
    void Update()
    {
        // Capture horizontal input from keyboard or joystick and calculate movement speed.
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; 

        // Update the Speed parameter in the Animator with the absolute value of horizontal movement.
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 

        // Process vertical input from the joystick for jumping and crouching.
        float verticalMove = joystick.Vertical;

        // Trigger jump logic if joystick is pushed up and not already jumping.
        if (verticalMove >= 0.5f && !isJumping)
        {
            jump = true; // Set jump flag to true.
            isJumping = true; // Prevent multiple jump triggers.
            Debug.Log("Jump Button Pressed"); // Debug log for jump action.
            jumpsound.Play(); // Play jump sound effect.
        }
        else if (verticalMove < 0.5f && isJumping)
        {
            isJumping = false; // Reset jump state when joystick is released.
        }

        // Handle crouch logic if joystick is pushed down.
        if (verticalMove <= -0.5f)
        {
            crouch = true; // Set crouch flag to true.
        }
        else
        {
            crouch = false; // Reset crouch flag when joystick is released.
        }

        // Additional keyboard input for jumping and crouching.
        if (Input.GetButtonDown("Vertical") && !isJumping)
        {
            jump = true; // Trigger jump action.
            Debug.Log("Jump Button Pressed"); // Debug log for jump action.
            jumpsound.Play(); // Play jump sound effect.
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true; // Trigger crouch action.
            Debug.Log("Crouch Button Pressed"); // Debug log for crouch action.
            crouchsound.Play(); // Play crouch sound effect.
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false; // Reset crouch flag when crouch button is released.
        }
    }

    // Updates the Animator parameter for crouching.
    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching); // Update the Animator's crouching state.
    }

    // FixedUpdate is called at fixed intervals for physics-based movement.
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump); // Move the player using the CharacterController2D script.
        jump = false; // Reset jump flag after processing.
    }
}
