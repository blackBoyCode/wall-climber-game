using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public Image cursor;
    public Sprite red;
    public Sprite blue; 

	float runSpeed = 5.0f;
	float mouseSensitivity = 2.0f;

    bool gotGun;

	Transform myTransform;

	CharacterController cc;

	Vector3 mouseMove;
	Vector3 move;
    float velocity;

	Transform cameraParentTransform;
	Transform cameraTransform;

    float gravity = 20.0f;
    float jumpSpeed = 20.0f;

    public GameObject SpawnCube;

    void Start () {

        gotGun = false;
		move = Vector3.zero;
		myTransform = transform;
		cc = GetComponent <CharacterController> ();
		cameraTransform = Camera.main.transform;
		cameraParentTransform = cameraTransform.parent;
	}

	void Update () {
		Vector3 inputMoveXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		float inputMoveXZMgnitude = inputMoveXZ.sqrMagnitude;
		inputMoveXZ = myTransform.TransformDirection(inputMoveXZ);
		if (inputMoveXZMgnitude <= 1)
			inputMoveXZ *= runSpeed;
		else
			inputMoveXZ = inputMoveXZ.normalized * runSpeed;

		if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
		{
            Quaternion cameraRotation = cameraTransform.rotation;
			cameraRotation.x = cameraRotation.z = 0;
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, cameraRotation, 10.0f * Time.deltaTime);

			move = Vector3.MoveTowards(move, inputMoveXZ, runSpeed);
		}
		else
		{
			move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMgnitude) * runSpeed);
		}
	
		float speed = move.sqrMagnitude;

        if (cc.isGrounded)
        {
            cursor.sprite = red;

            velocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity = jumpSpeed;
            }
        }
        else
        {
            cursor.sprite = blue;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity = -0.1f;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if(velocity <= 0)
                    gravity = 1.0f;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                gravity = 20.0f;
            }

            velocity -= (gravity * Time.deltaTime);

            if (Input.GetMouseButtonDown(0) && gotGun)
            {
                Instantiate(SpawnCube, Camera.main.transform.position + Camera.main.transform.forward * 8.0f, Quaternion.identity);
            }

        }

        move.y = velocity;
        cc.Move(move * Time.deltaTime);

        cameraParentTransform.position = myTransform.position;
		mouseMove += new Vector3(-Input.GetAxisRaw("Mouse Y") * mouseSensitivity, Input.GetAxisRaw("Mouse X") * mouseSensitivity, 0);

		cameraParentTransform.localEulerAngles = mouseMove;
    }



     void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "gun") {
            gotGun =true;
        }

       
            //switch ("player")
           // {

             //   case "checkPoint_1":
             //       greenArrow.transform.position = other.transform.position;
              //      break;
              //  case "checkPoint_2":
                //    greenArrow.transform.position = checkPoint_2.transform.position;
                  //  break;
                //case "checkPoint_3":
                    //greenArrow.transform.position = checkPoint_3.transform.position;
                    //break;
                //default:
                  //  print("none above");
                    //break;


          //  }


        


    }


}
