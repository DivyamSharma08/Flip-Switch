using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

	public Animator skyAnimator; 
	public Animator cityAnimator;
    public GameObject GameOverScreen;
    public Text scoreOnScreen;
    public int score;
    public Text highScore;
    public Text coinOnScreen;
    public Text gOCoins;
    public bool ded=false;
    public CanvasButtons butts;
    private Color tempC;
    private Color tempKC;
    public int numofkunai=0;
    public GameObject Kunai;
    private float kunaiTime = 7f;
    public Image kunaiBarBg;
    public Image kunaiBar;
    private bool kunaiThrow = false;
    private bool canThrow = false;

    public GameObject HandAnim;

    public AudioSource CoinSound;
    public AudioSource KunaiPickSound;
    public AudioSource KunaiThrowSound;


    // Start is called before the first frame update
    void Start(){
        GameObject mobj = GameObject.FindGameObjectWithTag("MSMusic");
        if(mobj!=null)
            Destroy(mobj.gameObject);
        Time.timeScale = 1;
        score = PlayerPrefs.GetInt("Score", 0);
        GameOverScreen.SetActive(false);
        scoreOnScreen.text = "Score: "+score;
        coinOnScreen.text = "Coins: " + PlayerPrefs.GetInt("NumOfCoins", 0);
        tempC = coinOnScreen.color;
        tempC.a = 0; 
        coinOnScreen.color = tempC;

        tempKC = kunaiBar.color;
        tempKC.a = 0;
        kunaiBar.color = tempKC;
        kunaiBarBg.color = tempKC;



        StartCoroutine(Scorer());
        StartCoroutine(HandAnimDest());
    }

    // Update is called once per frame
    void Update(){
        scoreOnScreen.text = "Score: "+score;
        if (kunaiThrow)
        {
            if (kunaiTime > 0)
            {
                kunaiTime -= Time.deltaTime;
                kunaiBar.fillAmount = kunaiTime / 7f;
            }
            else
                canThrow = false;
        }
    }

    void FixedUpdate(){
    	skyAnimator.speed +=  0.00002f;
    	cityAnimator.speed +=  0.00002f;

    }

    public void GameOver()
    {
        StartCoroutine(TimeScaleDead());
        if (PlayerPrefs.GetInt("HighScore", 0) <= score)
            PlayerPrefs.SetInt("HighScore", score);
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        GameOverScreen.SetActive(true);
        gOCoins.text = "Coins: " + PlayerPrefs.GetInt("NumOfCoins", 0);

    }

    public void AddCoin()
    {
        PlayerPrefs.SetInt("NumOfCoins", PlayerPrefs.GetInt("NumOfCoins", 0)+1);
        score += 2;
        tempC.a = 1;
        coinOnScreen.color = tempC;
        CoinSound.Play();
        coinOnScreen.text = "Coins: " + PlayerPrefs.GetInt("NumOfCoins", 0);
        StopCoroutine(FadeOutCoinText());
        StartCoroutine(FadeOutCoinText());

    }

    public void AddKunai()
    {

        KunaiPickSound.Play();
        numofkunai += 1;
        if (numofkunai == 3)
        {
            kunaiThrow = true;
            canThrow = true;
            tempKC.a = 1;
            kunaiBar.color = tempKC;
            kunaiBarBg.color = tempKC;
            numofkunai = 0;
            StartCoroutine(KunaiSpawner());
        }
    }
    public IEnumerator KunaiSpawner()
    {
        while (canThrow)
        {
            KunaiThrowSound.Play();
            Instantiate(Kunai, new Vector3(0, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        
        kunaiThrow = false;
        StartCoroutine(FadeOutKunaiBar());
        kunaiTime = 7f;
    }

    public IEnumerator Scorer()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            score += 1;
        }
    }

    public IEnumerator HandAnimDest()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOutHand());
    }

    public IEnumerator FadeOutHand()
    {
        Color temph = HandAnim.GetComponent<Image>().color;
        while (temph.a > 0.01)
        {
            temph.a -= 0.022f;
            HandAnim.GetComponent<Image>().color = temph;
            
            yield return new WaitForEndOfFrame();
        }

    }

    public IEnumerator TimeScaleDead()
    {
        while (true && Time.timeScale > 0)
        {
            yield return new WaitForSeconds(0.3f);
            Time.timeScale -= 0.2f;
        }
        if (Time.timeScale < 0)
            Time.timeScale = 0;
    }

    public IEnumerator FadeOutCoinText()
    {
        yield return new WaitForSeconds(0.8f);
        while (tempC.a > 0.01)
        {
            tempC.a -= 0.022f;
            coinOnScreen.color = tempC;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator FadeOutKunaiBar()
    {
        while (tempKC.a > 0.01)
        {
            tempKC.a -= 0.022f;
            kunaiBar.color = tempKC;
            kunaiBarBg.color = tempKC;

            yield return new WaitForEndOfFrame();
        }
    }


}