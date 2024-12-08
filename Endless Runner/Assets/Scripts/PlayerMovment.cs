using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; // Reference to the CharacterController2D script
    public float runSpeed = 40f; // Speed of the player
    AudioSource jumpsound; // Reference to the AudioSource component
    AudioSource crouchsound; // Reference to the AudioSource component
    float horizontalMove = 0f; // Variable to store the horizontal movement of the player
    bool jump = false; // Variable to store if the player is jumping
    bool crouch = false; // Variable to store if the player is crouching
    public Joystick joystick;

    public Animator animator; // Reference to the Animator component

    private bool isJumping = false; // To track if the player is already jumping

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // Get the horizontal movement of the player
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // Set the Speed parameter in the Animator to the absolute value of horizontalMove
        Input.GetAxisRaw("Horizontal"); // Returns the value of the virtual axis identified by axisName
        AudioSource[] audioSources = GetComponents<AudioSource>(); // Get all AudioSource components
        jumpsound = audioSources[0]; // Assign the first one to jumpsound
        crouchsound = audioSources[1]; // Assign the second one to crouchsound
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // Get the horizontal movement of the player
        
        float verticalMove = joystick.Vertical;

        // Trigger jump when swiping up for the first time
        if (verticalMove >= 0.5f && !isJumping)
        {
            jump = true;
            isJumping = true; // Mark as jumping to avoid multiple triggers
            Debug.Log("Jump Button Pressed");
            jumpsound.Play(); // Play the jump sound
        }
        else if (verticalMove < 0.5f && isJumping)
        {
            isJumping = false; // Reset the jump trigger when joystick is no longer pushed up
        }

        // Handle crouching
        if (verticalMove <= -0.5f)
        {
            crouch = true;
            //Debug.Log("Crouch Button Pressed");
        }
        else
        {
            crouch = false;
        }


        // Handle crouch and jump via keyboard (optional)
        if (Input.GetButtonDown("Vertical") && !isJumping)
        {
            Debug.Log("Jump Button Pressed");
            jumpsound.Play();
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log("Crouch Button Pressed");
            crouchsound.Play();
            
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }




    public void onCrouching(bool isCrouching)
    {
        //Debug.Log("Crouching");
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false; // Reset jump after applying it in FixedUpdate
    }
}
