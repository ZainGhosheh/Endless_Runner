using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller; //Reference to the CharacterController2D script
    public float runSpeed = 40f; //Speed of the player
    float horizontalMove = 0f; //Variable to store the horizontal movement of the player
    bool jump = false; //Variable to store if the player is jumping
    bool crouch = false; //Variable to store if the player is crouching

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //When the player presses the jump button, the jump variable is set to true
        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
        //When the player presses the crouch button, the crouch variable is set to true
        if (Input.GetButtonDown("Crouch")){
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
