using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadinAsy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AnimationScreen;
    public GameObject SkipButton;
    public AsyncOperation op;
    float prog;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((prog == 1))
        {
            SkipButton.SetActive(true);
        }

    }
    public void Load()
    {
        StartCoroutine(LoadAs());
        StartCoroutine(AnimDone());
    }
    
    IEnumerator AnimDone()
    {
        yield return new WaitForSeconds(67f);
        SkipButtonPressed();
    }

    IEnumerator LoadAs()
    {
        AnimationScreen.SetActive(true);

        op = SceneManager.LoadSceneAsync("GameScene");
        op.allowSceneActivation = false;
        
        
        while (!op.isDone)
        {
            prog = Mathf.Clamp01(op.progress / 0.9f);
            yield return null;
        }

    }

    public void SkipButtonPressed()
    {
        op.allowSceneActivation = true;
    }
}
