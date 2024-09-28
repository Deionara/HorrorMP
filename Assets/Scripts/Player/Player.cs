using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform Camera;
    public CharacterController Controller;

    public float speed;
    public float jumpForce;
    public float sens = 0.2f;
    private float gravity = -9.81f;

    Vector3 InputMovement;
    Vector2 InputMouse;
    [SerializeField] Vector3 Velocity;
    private float xRot;

    private void Start()
    {
        
    }

    private void Update()
    {
        InputMovement = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
        InputMouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        Movement();
        MoveCamera();
    }

    void Movement()
    {
        Vector3 MoveVector = transform.TransformDirection(InputMovement);

        

        if (Controller.isGrounded)
        {
            Velocity.y = -1;

            if (Input.GetButtonDown("Jump"))
            {
                Velocity.y = jumpForce;
            }
        }
        else
            Velocity.y -= gravity * -2f * Time.deltaTime;

        Controller.Move(MoveVector * speed * Time.deltaTime);
        Controller.Move(Velocity * Time.deltaTime);
    }

    void MoveCamera()
    {
        xRot -= InputMouse.y * sens;

        transform.Rotate(0, InputMouse.x * sens, 0);
        Camera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }
}
