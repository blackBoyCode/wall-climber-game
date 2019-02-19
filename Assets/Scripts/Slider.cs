using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<SphereCollider>().enabled = true;
            other.GetComponent<CharacterController>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<SphereCollider>().enabled = false;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
