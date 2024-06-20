using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    public float lerpRate;

    public bool gameOver;
    void Start()
    {
        gameOver = false;
        offset = player.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        if(!gameOver)
        {
            Follow();
        }
    }

    void Update()
    {
        
    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetpos = player.transform.position - offset;
        pos = Vector3.Lerp(pos, targetpos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
