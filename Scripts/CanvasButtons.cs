using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject VolumeOffButton;
    public GameObject VolumeOnButton;
    public GameObject pauseGameScreen;
    public Text payOrnNotEnough;

    void Start()
    {
        payOrnNotEnough.text = "(Pay 20 Coins)";

        if (AudioListener.volume == 0f)
        {
            VolumeOffButton.SetActive(false);
            VolumeOnButton.SetActive(true);
        }
        else
        {
            VolumeOffButton.SetActive(true);
            VolumeOnButton.SetActive(false);
        }
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseGameScreen.SetActive(true);
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
        pauseGameScreen.SetActive(false);
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            pauseGame();
    }

    public void VolOn()
    {
        VolumeOffButton.SetActive(true);
        VolumeOnButton.SetActive(false);
        AudioListener.volume = 1f;


    }
    public void VolOff()
    {
        VolumeOffButton.SetActive(false);
        VolumeOnButton.SetActive(true);
        AudioListener.volume = 0f;

    }

    public void continuePlay()
    {
        if (PlayerPrefs.GetInt("NumOfCoins", 0)>=20)
        {
            PlayerPrefs.SetInt("NumOfCoins", PlayerPrefs.GetInt("NumOfCoins")-20);
            PlayerPrefs.SetInt("Score", GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else {
            payOrnNotEnough.text = "(Not Enough Coins)";
            payOrnNotEnough.color = Color.red;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("HomeScreen");
    }

}
