using UnityEngine;
using UnityEngine.Events;

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
    public Data data;
    public bool isPlaying = false;
    public UnityEvent onPlay = new  UnityEvent();
    public UnityEvent onGameOver = new  UnityEvent();

    private void Start()
    {
     
        string loadedData = SaveSystem.Load("save");
        if(loadedData != null){
            data = JsonUtility.FromJson<Data>(loadedData);
        } else{
            data = new Data();
        }
    }

    private void Update()
    {
        isPlaying = GameObject.Find("Player") != null;
        if (isPlaying)
        {

            currentScore += Time.deltaTime;
        }
        else
        {
            currentScore = 0f;
        }


    }
    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        currentScore = 0f;

    }

    public void gameOver()
    {
        if (data.highScore < currentScore)
        {
            data.highScore = currentScore;
            string saveString = JsonUtility.ToJson(data);
            SaveSystem.Save("save", saveString);
        }
        isPlaying = false;
        onGameOver.Invoke();
    }

    public string PrettyScore() {
        return Mathf.RoundToInt(currentScore).ToString();
    }
    
     public string PrettyhighScore() {
        return Mathf.RoundToInt(data.highScore).ToString();
    }
}
