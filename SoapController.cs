/* Player movement controller */

using UnityEngine;

public class SoapController : MonoBehaviour
{
    public float moveSpeed = 18f;
    public float jumpForce = 9f;
    public float maxSpeed = 12f;
    public LayerMask groundLayer;

    private Rigidbody rb;

    private float moveX;
    private float moveZ;

    private bool jumpQueued;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Soap_Player is missing a Rigidbody.");
        }
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            0.8f,
            groundLayer
        );

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpQueued = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement =
            new Vector3(moveX, 0f, moveZ);

        rb.AddForce(
            movement * moveSpeed,
            ForceMode.Force
        );

        Vector3 flatVelocity =
            new Vector3(
                rb.linearVelocity.x,
                0f,
                rb.linearVelocity.z
            );

        if (flatVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity =
                flatVelocity.normalized * maxSpeed;

            rb.linearVelocity =
                new Vector3(
                    limitedVelocity.x,
                    rb.linearVelocity.y,
                    limitedVelocity.z
                );
        }

        if (jumpQueued)
        {
            rb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.Impulse
            );

            jumpQueued = false;
        }
    }
}
