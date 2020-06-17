using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    private int Score = 0;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (!Global.onLoseScreen)
        {
            if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
                StartGame();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("GameScene");
                Global.onLoseScreen = false;
            }
            StartGame();
        }
        print("Global.onLoseScreen = " + Global.onLoseScreen);
    }

    public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        if (!Global.onLoseScreen)
        {
            Txt_Message.text = "";
            Txt_Score.text = "SCORE : 0";
        }
        else
        {
            print("START IN GAME OVER SCENE");
            Txt_Message.text = "GAMEOVER! \nPRESS ENTER TO RESTART GAME.";
            Txt_Message.color = Color.red;
            Txt_Score.text = "SCORE : " + Global.Score;
        }
        
    }

    public void GameOver()
    {
        Global.Score = Score;
        Global.onLoseScreen = true;
        SceneManager.LoadScene("GameOverScene");
    }
}
