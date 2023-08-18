using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Gameplay,
        Paused,
        Gameover
    }

    public GameState currentState;

    public GameState previousState;

    [Header("Screens")]
    public GameObject pauseScreen;
    public GameObject resultScreen;

    public TMP_Text scoreEndDisplay;
    public TMP_Text scoreDisplay;
    int score;
    float time;
    float timeStart = 1f;
    public bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("EXTRA" + this + "DELETED");
        }

        DisableScreens();
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.Gameplay:
                UpdateScore();
                break;

            case GameState.Paused:
                break;

            case GameState.Gameover:
                if (!isGameOver)
                {
                    isGameOver = true;
                    Time.timeScale = 0f;
                    Debug.Log("GAME IS OVER");
                    DisplayResults();
                }
                break;

            default:
                Debug.LogWarning("state does not exist");
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if (currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            Debug.Log("Game is paused");
        }
    }

    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            Debug.Log("Game is resumed");
        }
    }

    void DisableScreens()
    {
        pauseScreen.SetActive(false);
        resultScreen.SetActive(false);
    }

    public void GameOver()
    {
        scoreEndDisplay.text = scoreDisplay.text;
        ChangeState(GameState.Gameover);
    }

    public void DisplayResults()
    {
        resultScreen.SetActive(true);
    }

    void UpdateScore()
    {
        time -= Time.deltaTime;
        scoreDisplay.text = string.Format("Score: " + "{0}", score);
        if (time <= 0)
        {
            score += 1;
            time = timeStart;
        }
    }
}
