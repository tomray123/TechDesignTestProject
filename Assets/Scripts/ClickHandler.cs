using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    // Enables next level button if true
    [SerializeField]
    private bool enableUIButton;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (animator)
        {
            animator.SetTrigger("Enable");
        }
    }
}
