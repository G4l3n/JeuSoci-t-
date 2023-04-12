using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public Rigidbody2D Player;
    public Player player;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("Menu");
            }
        }
        if(Time.timeSinceLevelLoad > 1.5f)
        {
            Player.freezeRotation = false;
            Player.gravityScale = 1;
            player.canJump = true;
        }
        else
        {
            Player.freezeRotation = true;
            Player.gravityScale = 0;
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
