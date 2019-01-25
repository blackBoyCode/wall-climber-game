using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown (KeyCode.Space))
        {

            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
    }
}
