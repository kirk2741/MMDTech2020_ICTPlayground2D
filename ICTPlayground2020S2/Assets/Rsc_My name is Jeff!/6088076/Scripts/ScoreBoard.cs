using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text highScore;
    public static Text highScoreStatic;

    // Start is called before the first frame update
    void Start()
    {
        highScoreStatic = highScore;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreStatic.text = "HighScore: "+PlayerPrefs.GetInt("HighScore").ToString();
        }
        
    }

    // Update is called once per frame
    public static void setScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (ScoreSystem.theScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", ScoreSystem.theScore);
                highScoreStatic.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", ScoreSystem.theScore);
            highScoreStatic.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public static void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreStatic.text = "HighScore: 0";
    }

}
