using UnityEngine;

public class GameManager : MonoBehaviour
{

    
    #region Singleton

    public static GameManager Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion


    public float currentScore = 0f;

    public bool isPlaying = false;


    private void Update()
    {
        isPlaying = true;
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }

        // if (Input.GetKeyDown("k"))
        // {
        //     isPlaying = true;
        // }
    }


    public void gameOver()
    {
        isPlaying = false;
        currentScore = 0f;
    }

    public string PrettyScore() {
        return Mathf.RoundToInt(currentScore).ToString();
    }
    
}
