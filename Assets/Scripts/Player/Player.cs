using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    public float moveSpeed = 550f;
    public float moveFriction = 15f;

    public float jumpForce;

    Rigidbody rb;
    public GroundCheck check;
    public Vector3 velocity;

    public Transform camRoot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandle();
        JumpHandle();
    }

    void JumpHandle()
    {
        if (check.is_Ground && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void MovementHandle()
    {
        Vector2 inputDir = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        

        if (check.is_Ground)
        {
            if (inputDir != Vector2.zero)
            {
                velocity.x = Mathf.Lerp(velocity.x, inputDir.x * speed, 5);
                velocity.z = Mathf.Lerp(velocity.z, inputDir.y * speed, 5);
            }
            else 
            {
                velocity.x = Mathf.Lerp(velocity.x, 0, moveFriction * Time.deltaTime);
                velocity.z = Mathf.Lerp(velocity.z, 0, moveFriction * Time.deltaTime);
            }
        }
        rb.linearVelocity = transform.rotation * new Vector3( velocity.x, rb.linearVelocity.y, velocity.z);
    }
}
