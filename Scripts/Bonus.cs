using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    // Start is called before the first frame update
    private LevelManager Lman;
    void Start()
    {
        Lman = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && gameObject.tag=="Coin")
        {
            Lman.AddCoin();
            Destroy(this.gameObject);
        }
        
        else if (other.tag == "Player" && gameObject.tag == "Kunai")
        {
            Lman.AddKunai();
            Destroy(this.gameObject);
        }

    }
}
