using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //goto next scene
        SceneManager.LoadScene("Final_2DSpaceShooting");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void BossFight()
    {
        SceneManager.LoadScene("BossFight");
    }


}
    