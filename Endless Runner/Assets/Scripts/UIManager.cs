using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject gameObjectUI;   
    [SerializeField] private TextMeshProUGUI gameOverScoreUI;
    [SerializeField] private TextMeshProUGUI gameOverhighscoreUI;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayButtonHandler()
    {
        gm.StartGame();
    }

    public void ActivateGameOverUI()
    {
        gameObjectUI.SetActive(true); 
        gameOverScoreUI.text = "Score: " + gm.PrettyScore();
        gameOverhighscoreUI.text = "Highscore: " + gm.PrettyhighScore();
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }


    public void CopyScoreToClipboard()
    {
        GUIUtility.systemCopyBuffer = "Score: " + gm.PrettyCopyScore();
    }
}
