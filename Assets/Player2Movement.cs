using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float freezeDuration = 1f;
    private bool isFrozen = false;
    private float freezeTimer = 0f;

    void Update()
    {
        // Player 2 movement with arrow keys
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
       
        // Update freeze timer if frozen
        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0f)
            {
                isFrozen = false;
                controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            }
            else
            {
                jump = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trail2"))
        {
            // Freeze the character
            Debug.Log("Collided with trail");
            isFrozen = true;
            freezeTimer = freezeDuration;
            // Stop character movement here 
        }
    }

    void FixedUpdate()
    {
        if (!isFrozen)
        {
            // Only move the character if not frozen
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
    }
}