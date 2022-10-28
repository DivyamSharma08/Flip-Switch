 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator camAnime;
    void Start()
    {
        camAnime = this.GetComponent<Animator>();


    }

    public void Shake()
    {
        camAnime.SetTrigger("Shake");
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
