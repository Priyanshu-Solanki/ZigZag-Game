using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("FallDown", 0.5f);
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;

        GetComponentInParent<Rigidbody>().isKinematic = false;

        Destroy(transform.parent.gameObject, 2f);
    }
}
