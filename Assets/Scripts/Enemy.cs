using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameObject respawn;
    public GameObject checkPoint_1, checkPoint_2, checkPoint_3, checkPoint_4, checkPoint_5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        //if(collider)
        print("OnTriggerEnter");
        CharacterController cc = collider.gameObject.GetComponent<CharacterController>();
        cc.enabled = false;
        if (CheckPoints.locationNumber == 1)
        {
            collider.transform.position = checkPoint_1.transform.position;

        }
        if (CheckPoints.locationNumber == 2)
        {
            collider.transform.position = checkPoint_2.transform.position;

        }
        if (CheckPoints.locationNumber == 3)
        {
            collider.transform.position = checkPoint_3.transform.position;

        }
        if (CheckPoints.locationNumber == 4)
        {
            collider.transform.position = checkPoint_4.transform.position;

        }


        if (Health.health > 0)
        {
            Health.health -= 1;
        }


    }
}
