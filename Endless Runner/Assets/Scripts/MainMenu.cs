using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("DifficultyMenu");
    }


    public void goToSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }


        public void goToDifficulty()
    {
        SceneManager.LoadScene("DifficultyMenu");
    }




    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    

}
