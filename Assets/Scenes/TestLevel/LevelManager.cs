using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float timeRemaining = 5;
    bool timerIsRunning = false;
    public Text timeText;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public static int player1Score = 0;
    public static int player2Score = 0;

    private void Awake()
    {

        Time.timeScale = 0;
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

        if (player1Score > 0)
        {
            player1ScoreText.text = player1ScoreText.text = string.Format("{0}", player1Score / 2);

        }
        if (player2Score > 0)
        {
            player2ScoreText.text = string.Format("{0}", player2Score / 2);

        }

    }

    private void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void PlayerScored(int player)
    {
        switch (player) {
            case 1:
                player1Score += 1;
                player1ScoreText.text = string.Format("{0}", player1Score / 2);
                break;
            case 2:
                player2Score += 1;
                player2ScoreText.text = string.Format("{0}", player2Score / 2);
                break;
            default:
                break;
        }

        Reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;

        BallController.onScore += PlayerScored;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.unscaledDeltaTime;

                //in progress
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                timeText.text = string.Format("{0}", seconds);

            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.gameObject.SetActive(false);

                //unpause game
                Time.timeScale = 1;
            }
        }

        //go back to main menu

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }


    }
}
