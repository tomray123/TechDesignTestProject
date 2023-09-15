using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    // Enables next level button if true
    [SerializeField]
    [Header("Enable button after click")]
    private bool enableUIButton;
    // Allow to repeat click actions many times
    [SerializeField]
    [Header("Allow multiple clicking")]
    private bool allowMultipleClick = false;
    private Animator animator;
    private AudioSource audioSource;
    private bool isClicked = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (animator && audioSource)
        {
            if (allowMultipleClick || !isClicked)
            {
                animator.SetTrigger("Enable");
                audioSource.Play();
                isClicked = true;
            }
        }
        else
        {
            Debug.LogWarning("Error in ClickHandler! Missing Animator or AudioSource components!");
        }
    }
}
