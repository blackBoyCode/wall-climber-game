using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowMovement : MonoBehaviour
{
    float startPos;
    float endPos;

    public float speed = 2;
    public float height = 0.5f;

    bool switchDown;

    // Start is called before the first frame update
    void Start()
    {
       // startPos = gameObject.transform.position.y;
       // endPos = startPos + 2f;

        switchDown = false;
    }

    // Update is called once per frame
    void Update()
    {

        moveArrowUpDown();

    }





    void moveArrowUpDown()
    {
        Vector3 pos = transform.position;
        
        float newY = Mathf.Sin(Time.time*speed);
        
        transform.position += new Vector3(0, newY, 0) * height;





    }


}
