using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public KeyCode interactKey;

    public float interactDistance = 2;

    public LayerMask interactableLayers;

    RaycastHit hit;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit,interactDistance, interactableLayers))
        {
            if (hit.collider.CompareTag("Door")) 
            { 
                Door door = hit.collider.GetComponent<Door>();
                print(door.gameObject.name);
                if (Input.GetKeyDown(interactKey)) {
                    if (door.isOpen)
                        door.Close();
                    else
                        door.Open(); 
                }
            } 
        }
    }
}
