using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    public Transform Camera;
    public Transform groundCheck;

    //Movement
    public float speed = 12f;
    public float jumpHeight = 3f;

    //Physics
    public float gravity = -9.81f; 
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _velocity;
    private bool _isGrounded;
    private bool _isMoving;
    private Vector3 _lastPosition;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _lastPosition = transform.position;
    }

    void Update()
    {
        // Ground Check
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset downward velocity when grounded
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        //Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Movement relative to camera
        Vector3 move = Camera.right * horizontal + Camera.forward * vertical;
        move.y = 0f; // Prevent movement based on camera tilt
        move.Normalize(); // Smooth diagonal movement

        // Apply movement and gravity in one call
        Vector3 finalMove = (move * speed) + _velocity;
        _controller.Move(finalMove * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        _velocity.y += gravity * Time.deltaTime;

        // Check if player is moving
        if (Vector3.Distance(_lastPosition, transform.position) > 0.01f && _isGrounded)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

        _lastPosition = transform.position;
    }

}
