using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    public bool isOpen;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open() { animator.SetBool("Open", true); isOpen = true; }

    public void Close() { animator.SetBool("Open", false); isOpen = false; }
}
