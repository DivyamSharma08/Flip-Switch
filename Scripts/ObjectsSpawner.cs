using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{

    public Vector3 Pos;
    public GameObject[] obstacles;
    public GameObject[] bonuses;
    public int[] spawnWhat;
    public int i = -1, l = -1;
    public float waitTime;
    //public bool dd = false;
    void Start()
    {
        spawnWhat = new int[] { 0, 1, 2 };
        Pos = transform.position;
        StartCoroutine(objSpawner());
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (waitTime > 0.5f)
            waitTime -= 0.00007f;//---------------

    }

    public IEnumerator objSpawner()
    {
        yield return new WaitForSeconds(waitTime);
        while (true)
        {
            int ss = Random.Range(1, 3);
            if (ss == 1)
            {
                spawnObjTop();
                yield return new WaitForSeconds(waitTime + 0.5f);
            }
            else
            {
                spawnObjBottom();
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    int RREx(int i, int j, int k)
    {         //Random Range Exclusion
        int num;
        do
        {
            num = Random.Range(i, j);
        } while (num == k);
        return num;
    }



    public void spawnObjBottom()
    {
        i = RREx(0, 3, l);
        //dd = true;
        if (spawnWhat[i] == 1)
        {
            int j = Random.Range(0, obstacles.Length);
            int k = Random.Range(-5, 18);
            Instantiate(obstacles[j], new Vector3(Pos.x + k, Pos.y - 9f, Pos.z), Quaternion.identity);

        }
        else if (spawnWhat[i] == 2)
        {
            int j = Random.Range(0, bonuses.Length);
            int k = Random.Range(-5, 18);
            Instantiate(bonuses[j], new Vector3(Pos.x + k, Pos.y - 9f, Pos.z), Quaternion.identity);
        }
    }

    public void spawnObjTop()
    {
        //while (dd == false)
         

            l = RREx(0, 3, i);
            if (spawnWhat[l] == 1)
            {
                int j = Random.Range(0, obstacles.Length);
                int k = Random.Range(-5, 18);
                Instantiate(obstacles[j], new Vector3(Pos.x + k, Pos.y + 9f, Pos.z), Quaternion.Euler(0f, 180f, 180f));
            }
            else if (spawnWhat[l] == 2)
            {
                int j = Random.Range(0, bonuses.Length);
                int k = Random.Range(-5, 18);
                Instantiate(bonuses[j], new Vector3(Pos.x + k, Pos.y + 9f, Pos.z), Quaternion.Euler(0f, 180f, 180f));
            }
        
    }

}
