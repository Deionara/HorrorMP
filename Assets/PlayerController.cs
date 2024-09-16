using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private PlayerInput playerController;
    public GroundCheck groundCheck;
    Rigidbody rb;
    InputAction moveAction;
    InputAction jumpAction;

    void Start()
    {
        playerController = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        moveAction = playerController.actions.FindAction("Move");
        jumpAction = playerController.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if(groundCheck.is_Ground)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (groundCheck.is_Ground) {
            Vector3 Velocity = Vector3.zero;
            Vector2 dir = moveAction.ReadValue<Vector2>();
            Velocity.x = Mathf.Lerp(Velocity.x, dir.x, 550 * Time.fixedDeltaTime);
            Velocity.z = Mathf.Lerp(Velocity.z, dir.y, 550 * Time.fixedDeltaTime);

            rb.linearVelocity = Velocity; 
        }
    }
}
