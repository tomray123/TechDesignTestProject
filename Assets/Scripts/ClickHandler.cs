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
    // Name of the sound to play after click
    [SerializeField]
    [Header("Name of the sound to play after click")]
    private string soundName;
    private bool isClicked = false;
    private Animator animator;
    private UIManager UIManager;
    private AudioManager audioManager;

    private void Awake()
    {
        UIManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioManager = AudioManager.Instance;
    }

    private void OnMouseDown()
    {
        // Check if animator and audio manager exist
        if (animator != null && audioManager != null)
        {
            // Do actions when first click or multiple clicks allowed
            if (allowMultipleClick || !isClicked)
            {
                animator.SetTrigger("Enable");
                audioManager.Play(soundName);
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
            Debug.LogWarning("Error in ClickHandler! Missing Animator or AudioManager components!");
            return;
        }
    }
}
