using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller; //Reference to the CharacterController2D script
    public float runSpeed = 40f; //Speed of the player
    AudioSource jumpsound; //Reference to the AudioSource component
    AudioSource crouchsound; //Reference to the AudioSource component
    float horizontalMove = 0f; //Variable to store the horizontal movement of the player
    bool jump = false; //Variable to store if the player is jumping
    bool crouch = false; //Variable to store if the player is crouching


    void Update()
    {

        Input.GetAxisRaw("Horizontal"); //Returns the value of the virtual axis identified by axisName
        AudioSource[] audioSources = GetComponents<AudioSource>(); // Get all AudioSource components
        jumpsound = audioSources[0];  // Assign the first one to jumpsound
        crouchsound = audioSources[1];  // Assign the second one to crouchsound
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //Get the horizontal movement of the player
        //When the player presses the jump button, the jump variable is set to true
        if (Input.GetButtonDown("Vertical"))
        {
            Debug.Log("Jump Button Pressed"); //Used for testing
            jumpsound.Play(); //Play the jump sound
            jump = true;

        }

        //When the player presses the crouch button, the crouch variable is set to true
        if (Input.GetButtonDown("Crouch")){
            Debug.Log("Crouch Button Pressed"); //Used for testing
            crouchsound.Play(); //Play the crouch sound
            crouch = true;

            
        } 
        //When the player releases the crouch button, the crouch variable is set to false
        else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;


    }
}
