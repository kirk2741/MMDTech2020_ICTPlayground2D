using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool isWon = false;
    public GameObject WonUI;
    public GameObject WonScoretext;

    void Start()
    {
        Time.timeScale = 1f;
        isWon = false;
        WonUI.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayGame();
        }
        if (Health.isDie)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayGame();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
            
        if (isWon)
        {
            WonUI.SetActive(true);
            WonScoretext.GetComponent<Text>().text = "SCORE: " + ScoreSystem.theScore;
            ScoreBoard.setScore();
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.R))
            {
               ScoreBoard.ClearHighScore();

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayGame();
            }



        }
    }   

        public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //goto next scene
        SceneManager.LoadScene(0);
    }

}
    