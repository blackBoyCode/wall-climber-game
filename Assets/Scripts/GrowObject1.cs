using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowObject1 : MonoBehaviour
{
    public float GrowLimitTest;
   // float test;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Grow", 0.5f, 0.01f);
       // test = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Grow() {

        // test += 0.1f;

        Vector3 test = new Vector3(0.5f, 0.5f, 0.5f);
        if (transform.localScale.x != GrowLimitTest)
            transform.localScale = transform.localScale + test;
        else CancelInvoke();


    }
}
