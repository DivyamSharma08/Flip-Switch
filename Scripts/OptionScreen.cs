using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionScreen : MonoBehaviour
{
    public GameObject VolumeOffButton;
    public GameObject VolumeOnButton;
    public GameObject HowToPlay;
    public GameObject Credits;
    public GameObject cheatOnText;
    public GameObject cheatOffText;

    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
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

    public void howto()
    {
        HowToPlay.SetActive(true);
    }

    public void credits()
    {
        Credits.SetActive(true);
    }

    public void blackButt(GameObject what)
    {
        what.SetActive(false);
    }
    public void Home()
    {
        SceneManager.LoadScene("HomeScreen");
    }
    public void cheatButton()
    {
        if (PlayerPrefs.GetInt("CheatMode", 0) == 0)
        {
            PlayerPrefs.SetInt("CheatMode", 1);
            cheatOnText.SetActive(true);
            StartCoroutine(TurnOff(cheatOnText));
        }
        else
        {
            PlayerPrefs.SetInt("CheatMode", 0);
            cheatOffText.SetActive(true);
            StartCoroutine(TurnOff(cheatOffText));
        }
    }

    public IEnumerator TurnOff(GameObject obj)
    {
        yield return new WaitForSeconds(0.8f);
        obj.SetActive(false);
    }
}
