using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public GameObject particle;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.5f, 0),Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject part = Instantiate(particle, transform.position, particle.transform.rotation) as GameObject;
            Destroy(gameObject);
            Destroy(part, 1f);
        }
    }
}
