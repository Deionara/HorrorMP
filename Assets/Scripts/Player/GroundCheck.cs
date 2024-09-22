using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool is_Ground = true;
    public float distance = 1.5f;
    public LayerMask layer;

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, distance, layer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.down * distance);
    }

}
