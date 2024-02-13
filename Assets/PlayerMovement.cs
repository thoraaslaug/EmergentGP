using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float freezeDuration = 5f; // Adjusted freeze duration to 5 seconds
    private bool isFrozen = false;
    private float freezeTimer = 0f;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

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
            // If not frozen, allow normal movement
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trail"))
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
