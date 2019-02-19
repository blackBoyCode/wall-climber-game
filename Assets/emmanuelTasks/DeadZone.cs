using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    public GameObject respawn;
    public GameObject player;
    public float speed = 2;

   // private float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        //movingObject.transform.Translate(new Vector3(horizontal, 0, vertical) * speed);

    }

    //
    void OnTriggerEnter(Collider collider)
    {
        //if(collider)
        print("OnTriggerEnter");
        CharacterController cc = collider.gameObject.GetComponent<CharacterController>();
        cc.enabled = false;
        collider.transform.position = respawn.transform.position;
        
    }


}
