using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float groundDrag;

    public Transform orientation;
    private Vector3 moveDirection;
    private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get directional input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Apply speed cap (if reached)
        CapSpeed();

        // Apply ground drag
        rb.linearDamping = groundDrag;
    }

    void FixedUpdate()
    {
        // Find orientation to move on
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Move player
        rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
    }

    void CapSpeed()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
