using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    // Start is called before the first frame update
    public int moveSpeed;
    public AudioSource KunaiDestroySound;
    public ParticleSystem explosion;
    private void Awake()
    {
        gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        transform.localPosition = new Vector3(0, 0, 0);
    }
    void Start()
    {
        gameObject.transform.SetParent(null);
        StartCoroutine(Destroyer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacles")
        {
            KunaiDestroySound.Play();
            explosion.Play();
            Destroy(other.gameObject);
        }

    }

    public IEnumerator Destroyer()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Destroy(this.gameObject);

        }
    }

}
