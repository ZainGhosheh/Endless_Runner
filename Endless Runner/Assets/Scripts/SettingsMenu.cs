using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

}
