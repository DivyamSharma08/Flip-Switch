using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public Text HighScore;
    public GameObject SureScreen;

    void Start()
    {
        HighScore.text = "High Score: "+ PlayerPrefs.GetInt("HighScore",0);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("GameScene");

    }

    public void OptionScene()
    {
        SceneManager.LoadScene("OptionScreen");
    }

    public void ExternalPages(int num)
    {
        switch (num)
        {
            case 1:
                Application.OpenURL("https://www.facebook.com/");
                break;
            case 2:
                Application.OpenURL("https://www.instagram.com/");
                break;
            case 3:
                Application.OpenURL("https://play.google.com/store/");
                break;
        }
    }

    public void QuitGame()
    {
        SureScreen.SetActive(true);
    }

    public void yes()
    {
        Application.Quit();
    }
    public void no()
    {
        SureScreen.SetActive(false);
    }
}
