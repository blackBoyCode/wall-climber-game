using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowObject : MonoBehaviour
{
    public float GrowLimitTest;
    float test;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Grow", 0.5f, 0.01f);
        test = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Grow() {

       // test += 0.1f;
        if (transform.localScale.x != GrowLimitTest)
            transform.localScale += Vector3.one;
        else CancelInvoke();


    }
}
