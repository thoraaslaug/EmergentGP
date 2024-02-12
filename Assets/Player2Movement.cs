using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        // Player 2 movement with arrow keys
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}