using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

    public GameObject checkPoint_1, checkPoint_2, checkPoint_3;
    public GameObject GreenArrow;

    public int locationNumber;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        locationNumber = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(locationNumber);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player") {
            if (locationNumber == 0)
            {
                time = Time.time;
                GreenArrow.transform.position = checkPoint_2.transform.position;
                locationNumber = 1;
                Debug.Log(locationNumber);
                Debug.Log(checkPoint_2.transform.position);
            }
            if (locationNumber == 1 && (Time.time - time > 2))
            {
                time = Time.time;
                GreenArrow.transform.position = checkPoint_3.transform.position;
                locationNumber = 2;
            }
            if (locationNumber == 2 && (Time.time - time > 2))
            {
                //GreenArrow.transform.position = checkPoint_4.transform.position;
                locationNumber = 3;
            }

        }




        
    }

}
