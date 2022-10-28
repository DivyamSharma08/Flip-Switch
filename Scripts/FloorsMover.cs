using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorsMover : MonoBehaviour
{
    public float moveSpeed = 8f;
    public LevelManager Lman;
    void Start()
    {
        StartCoroutine(Destroyer());
        Lman = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (Lman.ded && gameObject.tag!="Bullet")
        {
            moveSpeed = 0f;
        }
    }

    void FixedUpdate()
    {
        moveSpeed += 0.0002f;

    }

    public IEnumerator Destroyer()
    {
        while (true)
        {
            yield return new WaitForSeconds(12f);
            Destroy(this.gameObject);

        }
    }
}
