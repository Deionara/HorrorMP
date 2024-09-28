using System.Collections;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public MeleeSO meleeSO;

    private bool IsDelay;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && !IsDelay)
        {
            StartCoroutine(Primary());
        }

        //
    }

    IEnumerator Primary()
    {
        animator.Play(meleeSO.primaryAnimName);

        IsDelay = true;
        yield return new WaitForSeconds(meleeSO.delay); 
        IsDelay = false;
    }
}
