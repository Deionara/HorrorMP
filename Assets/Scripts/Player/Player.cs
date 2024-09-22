using UnityEngine;
using Com.Player.GroundCheck;
public class Player : MonoBehaviour
{
    public float speed;
    public float moveSpeed = 550f;
    public float moveFriction = 15f;

    Rigidbody rb;
    public GroundCheck check;
    public Vector3 velocity;

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
    }

    void MovementHandle()
    {
        Vector2 inputDir = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (!check.IsGrounded())
        {
            velocity.y -= 9.8f * Time.deltaTime;
        }

        if (check.IsGrounded())
        {
            if (inputDir != Vector2.zero)
            {
                velocity.x = Mathf.Lerp(velocity.x, transform.forward.z * inputDir.x * speed, 5);
                velocity.z = Mathf.Lerp(velocity.z, transform.forward.z * inputDir.y * speed, 5);
            }
            else 
            {
                velocity.x = Mathf.Lerp(velocity.x, 0, moveFriction * Time.deltaTime);
                velocity.z = Mathf.Lerp(velocity.z, 0, moveFriction * Time.deltaTime);
            }
        }
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }
}
