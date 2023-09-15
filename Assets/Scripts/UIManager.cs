using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button nextLevelButton;
    private int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = false;
        }
        else
        {
            Debug.LogWarning("Missing Next Level Button!");
            return;
        }

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Enables next level button
    public void EnableNextLevelButton()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = true;
        }
        else
        {
            Debug.LogWarning("Missing Next Level Button!");
            return;
        }
    }

    public void LoadNextScene()
    {
        int totalScenesNumber = SceneManager.sceneCountInBuildSettings;
        if (currentSceneIndex == totalScenesNumber - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
