using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{

    public Vector3 Pos;
    public GameObject[] Floors;
    GameObject floorToSpawn;
    public float waitTime;
    int i = -1;
    int j = -1;
    // Start is called before the first frame update
    void Start()
    {
        Pos = transform.position;

        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        if(waitTime>0.5f)
            waitTime -= 0.0001f;

    }

    public IEnumerator spawner()
    {
        while (true)
        {
            
            
            spawnFloorTop();
            yield return new WaitForSeconds(waitTime + 0.25f);
            spawnFloorBottom();
            yield return new WaitForSeconds(waitTime);
        }
    }


    public void spawnFloorBottom()
    {
        i = Random.Range(0, Floors.Length);
        Instantiate(Floors[i], new Vector3(Pos.x , Pos.y - 9, Pos.z), Quaternion.identity);
    }

    public void spawnFloorTop()
    {
        j = Random.Range(0, Floors.Length);
        Instantiate(Floors[j], new Vector3(Pos.x , Pos.y + 9, Pos.z), Quaternion.Euler(0f,0f,180f));
    }



}
