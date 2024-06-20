using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject platformSpawner;

    [SerializeField] private float speed;
    Rigidbody rb;
    bool started = false;
    bool gameOver = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector3.forward * speed;
                started = true;

                GameManager.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = Vector3.down * 9.81f;

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            platformSpawner.GetComponent<PlatformSpawner>().gameOver = true;

            GameManager.instance.GameOver();
        }

        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = Vector3.right * speed;
        }
        else
        {
            rb.velocity = Vector3.forward * speed;
        }
    }
}
