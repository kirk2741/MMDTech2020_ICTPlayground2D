using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    
    public static bool GameisPause = false;
    public KeyCode keyToPress = KeyCode.Escape;
    public GameObject pauseMenuUI;
    private void Start()
    {
        Time.timeScale = 1f;
        GameisPause = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (GameisPause)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Restart();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Quit();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); //goto next scene
    }

    public void Quit()
    {
        Application.Quit();
    }

}
