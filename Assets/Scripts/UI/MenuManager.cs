using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameOverMenu gameOverMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                Time.timeScale = 1;

                pauseMenu.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;

                pauseMenu.gameObject.SetActive(true);
            }
        }
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HandleGameOver()
    {
        Time.timeScale = 0;
        gameOverMenu.gameObject.SetActive(true);
    }
}
