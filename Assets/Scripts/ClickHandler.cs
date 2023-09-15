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
    private UIManager UIManager;

    private void Awake()
    {
        UIManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        // Check if animator and audio source exist
        if (animator != null && audioSource != null)
        {
            // Do actions when first click or multiple clicks allowed
            if (allowMultipleClick || !isClicked)
            {
                animator.SetTrigger("Enable");
                audioSource.Play();
                isClicked = true;
                // Enabling next level button
                if (enableUIButton)
                {
                    if (UIManager != null)
                    {
                        UIManager.EnableNextLevelButton();
                    }
                    else
                    {
                        Debug.LogWarning("Couldn't find UIManger on current scene!");
                        return;
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("Error in ClickHandler! Missing Animator or AudioSource components!");
            return;
        }
    }
}
