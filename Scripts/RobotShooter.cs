using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer myRend;
    public GameObject bullet;
    public AudioSource LaserSound;
    void Start()
    {
        myRend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
      //  if (myRend.isVisible)
        //{
            
        //}
       // else
        //    Debug.Log("Not Visible");
        
    }

    private void OnBecameVisible()
    {
        GetComponent<Animator>().enabled = true;
        StartCoroutine(shoot());
        StartCoroutine(Dec());
    }


    public IEnumerator shoot()
    {
        yield return new WaitForSeconds(0.683f);
        LaserSound.Play();
        bullet.SetActive(true);

    }
    public IEnumerator Dec()
    {
        yield return new WaitForSeconds(1.35f);
        gameObject.SetActive(false);

    }
}
