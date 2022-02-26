using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isPaused { get; private set; }

    private void Awake()
    {
        Instance = this;
        isPaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(PlayerInput.Instance.restartButton))
            RestartScene();

        if (Input.GetKeyDown(PlayerInput.Instance.stopGameButton))
        {
            if (isPaused)
                ResumeGame();
            else
                StopGame();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StopGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
