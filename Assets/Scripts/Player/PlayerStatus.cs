using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance { get; private set; }
    public int maxHealth;
    [Header("Не трогай!")]
    public bool isAlive = true;
    public int health;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (!isAlive) return;

        if(health <= 0 )
        {
            isAlive = false;
        }
    }
}
