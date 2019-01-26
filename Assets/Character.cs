using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Character : MonoBehaviour
{
    private Rigidbody rb;

    private float movementSpeed = 20;
    private float gravity = -5;
    private CharacterController myController = null;
    private Vector3 moveDirection = Vector3.zero;

    private float rotationSpeed = 90;
    
    private  Vector3 rotationDirection = Vector3.zero;
    
    // Start is called before the first frame update
    void Awake()
    {
        myController = GetComponent<CharacterController>();

    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection =
            transform.TransformDirection(new Vector3(Input.GetAxis("Vertical") * movementSpeed, gravity, 0));

        myController.Move(moveDirection * Time.deltaTime);

        rotationDirection = new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
        transform.Rotate(rotationDirection * Time.deltaTime, Space.Self);
        
        if (Input.GetKeyDown (KeyCode.Space))
        {

            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
    }
}
