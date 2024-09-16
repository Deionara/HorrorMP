using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerController;
    Rigidbody rb;
    InputAction moveAction;
    void Start()
    {
        playerController = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        moveAction = playerController.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Velocity = Vector3.zero;
        Vector2 dir = moveAction.ReadValue<Vector2>();
        Velocity.x = Mathf.Lerp(Velocity.x,dir.x, 5 * Time.fixedDeltaTime);
        Velocity.z = Mathf.Lerp(Velocity.z, dir.y, 5 * Time.fixedDeltaTime);

        rb.linearVelocity = Velocity;
    }
}
