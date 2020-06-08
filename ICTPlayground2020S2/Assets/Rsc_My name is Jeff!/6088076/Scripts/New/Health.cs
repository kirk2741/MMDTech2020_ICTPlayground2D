using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public GameObject Player;
    public GameObject HealthText;
    public static int currentHealth;
    public Healthbar Heathbar;
    public int maxHealth;
    public GameObject die;
    public static bool isDie = false;
    public GameObject DieScoretext;
    public CircleHealthbar CirHeathbar;

    public GameObject Lifetext;
    public static int Life = 5;




    // Start is called before the first frame update
    void Start()
    {
        Life = 5;
        Time.timeScale = 1f;
        isDie = false;
        currentHealth = maxHealth;
        CirHeathbar.SetMaxHealth(maxHealth);
        die.SetActive(false);

    }


    void Update()
    {
        CirHeathbar.SetHealth(currentHealth);
        HealthText.GetComponent<Text>().text = "Health: " + currentHealth;
        Lifetext.GetComponent<Text>().text = "Extra Life: " + Life;
        if (currentHealth <= 0)
        {
            if(Life <= 0)
            {
                Gameover();
            }
            else
            {
                respawn();
            }
            
        }

        if (isDie)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ScoreBoard.ClearHighScore();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }




    }
    public void respawn()
    {
        Life -= 1;
        Lifetext.GetComponent<Text>().text = "Life: " + Life;
        Teleport.TeleportPlayer();
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        CirHeathbar.SetHealth(currentHealth);
    }




    public void Gameover()
    {
        ScoreBoard.setScore();
        Time.timeScale = 0f;
        isDie = true;
        die.SetActive(true);
        currentHealth = 0;
        DieScoretext.GetComponent<Text>().text = "SCORE: " + ScoreSystem.theScore;

    }




}
