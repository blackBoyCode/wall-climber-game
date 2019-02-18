using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //public Rigidbody rb;
    // Start is called before the first frame update


    //public float growSizeLimit, growRate, growTime;


    public GameObject prefabGrowTest;




    void Start()
    {
       // rb = gameObject.GetComponent<Rigidbody>();
       // InvokeRepeating("Grow", 0.5f, growTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            //rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);


            Instantiate(prefabGrowTest, new Vector3(5, 5, 5), Quaternion.identity);
        }

        //Grow();
        


    }


    void Grow(){

       // if(Input.GetKeyDown(KeyCode.A)){


         //  if(!(transform.localScale.x == growSizeLimit)) {
            
          //  transform.localScale += new Vector3(growRate, growRate, growRate);



          // }else
           //{
            //Destroy(this.gameObject, 2.0f);
           //}

           
           


       // }

    }




}
