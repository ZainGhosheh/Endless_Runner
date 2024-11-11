using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu: MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    void start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
