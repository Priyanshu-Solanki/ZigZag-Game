using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;

    Vector3 lastPos;
    float size;

    public bool gameOver;
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i=0;i<20;i++)
        {
            SpawnPlatforms();
        }

        InvokeRepeating("SpawnPlatforms", 0.2f, 0.2f);
    }

    void Update()
    {
        if(gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }
    void SpawnPlatforms()
    {
        int randomNo = Random.Range(0, 6);
        if(randomNo < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }
    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 10);
        if(rand<3)
        {
            Instantiate(diamond, pos + new Vector3(0,1f,0), diamond.transform.rotation);
        }

        lastPos = pos;
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 10);
        if (rand < 3)
        {
            Instantiate(diamond, pos + new Vector3(0, 1f, 0), diamond.transform.rotation);
        }

        lastPos = pos;
    }
}
