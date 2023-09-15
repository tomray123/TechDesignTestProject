using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    // Enables next level button if true
    [SerializeField]
    private bool enableUIButton;
    private Animator animator;
    private AudioSource audioSource;
    private bool isOpened = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (animator && audioSource)
        {
            if (!isOpened)
            {
                animator.SetTrigger("Enable");
                audioSource.Play();
                isOpened = true;
            }
        }
        else
        {
            Debug.LogWarning("Error in ClickHandler! Missing Animator or AudioSource components!");
        }
    }
}
