using UnityEngine;

public class Healkit : MonoBehaviour
{
    public int heal = 50;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<PlayerStatus>())
        {
            PlayerStatus.Instance.health += heal;
            Destroy(gameObject);
        }
            
    }
}
