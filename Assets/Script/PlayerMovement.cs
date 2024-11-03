using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameManager gameManager; // Reference to the GameManager
    public float initialForwardForce = 700f; // Initial forward force
    public float SidewayForce = 30f;
    public float JumpForce = 500f; // Jump force
    public float speedIncreaseRate = 10f; // Rate at which the speed increases
    public float maxForwardForce = 2000f; // Maximum speed limit

    private float currentForwardForce; // Current forward force
    private bool isGrounded; // Check if the player is on the ground

    void Start()
    {
        currentForwardForce = initialForwardForce; // Initialize current forward force
    }

    void Update()
    {
        // Restart game if R is pressed and game is not over
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.RestartGame();
        }

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump(); // Call the jump method
            
        }
    }

    void FixedUpdate()
    {
        // Move the player forward constantly
        rb.AddForce(0, 0, currentForwardForce * Time.deltaTime);

        // Move the player left and right using horizontal input
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(moveHorizontal * SidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        // Automatically increase forward speed over time
        if (currentForwardForce < maxForwardForce)
        {
            currentForwardForce += speedIncreaseRate * Time.deltaTime;
        }
    }

    void Jump()
    {
        // Apply upward force for jumping
        rb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
        isGrounded = false; // Set grounded to false when jumping
        Debug.Log("Jump!");
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if player is touching the ground
        if (collision.collider.CompareTag("Ground")) // Ensure your ground has the "Ground" tag
        {
            isGrounded = true; // Player is on the ground
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if player leaves the ground
        if (collision.collider.CompareTag("Ground")) // Ensure your ground has the "Ground" tag
        {
            isGrounded = false; // Player is no longer on the ground
        }
    }
}
