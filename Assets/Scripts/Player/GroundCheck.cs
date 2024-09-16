using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool is_Ground;
    private void Update()
    {
        is_Ground = IsGround();
    }
    private bool IsGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1))
            print("Grounded");
            return true;

        return false;
    }
}
