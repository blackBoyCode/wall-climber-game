using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlogPlayer : MonoBehaviour
{
    // Set the values of Camera
	[SerializeField]
	float gravity = 9.81f;
	[SerializeField]
	float runSpeed = 5.0f;
	[SerializeField]
	float mouseSensitivity = 50.0f;

	Transform myTransform;
	Transform model;

	CharacterController cc;

    // Set the values of the mouse movement
	Vector3 mouseMove;
	Vector3 move;
	Transform cameraParentTransform;
	Transform cameraTransform;

	void Awake()
	{
        // Set the current transform into the value
		myTransform = transform;
        // Get the CharacterController compoent
		cc = GetComponent <CharacterController> ();
        // Set the child transform(Player) into the value
		model = transform.GetChild(0);
        // Get the camera transform
		cameraTransform = Camera.main.transform;
        // Set the parent camera transform into the value 
		cameraParentTransform = cameraTransform.parent;
	}

	void Update()
	{

        ///
        //cc.attachedRigidbody;

		if (cc.isGrounded)
		{
            // if being on the ground, the movement is 1.0f;
			MoveCalc(1.0f);
		}
		else
		{
            // if not, the gravity affects
			move.y -= gravity * Time.deltaTime;

			MoveCalc(0.01f);
		}

        // set the value of movement
		cc.Move(move * Time.deltaTime);

	}

	void LateUpdate()
	{
        // Camera control by the mouse movement
		cameraParentTransform.position = myTransform.position + Vector3.up * 1.4f;
		mouseMove += new Vector3(0, Input.GetAxisRaw("Mouse X") * mouseSensitivity, 0);

        // set the limitation of the mouse for the height
        // x is the height
		if (mouseMove.x < -40)
			mouseMove.x = -40;
		else if (30 < mouseMove.x)
			mouseMove.x = 30;

		cameraParentTransform.localEulerAngles = mouseMove;
	}

	void MoveCalc(float ratio)
	{
//		float tempMoveY = move.y;

        // only needs xz value so y is 0
		move.y = 0;

        // get the keyboard value
		Vector3 inputMoveXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // get the distance of the next position
		float inputMoveXZMgnitude = inputMoveXZ.sqrMagnitude;
		inputMoveXZ = myTransform.TransformDirection(inputMoveXZ);
        // if speed is more than 1, set the nomalized value because it causes the double-speed
		if (inputMoveXZMgnitude <= 1)
			inputMoveXZ *= runSpeed;
		else
			inputMoveXZ = inputMoveXZ.normalized * runSpeed;

        // if there is the keyboard input, the direction can be changed by the mouse movement
		if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
		{
			Quaternion cameraRotation = cameraParentTransform.rotation;
			cameraRotation.x = cameraRotation.z = 0;
            // set the value of Slerp for the rotation
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, cameraRotation, 10.0f * Time.deltaTime);
			if (move != Vector3.zero)
			{
				Quaternion characterRotation = Quaternion.LookRotation(move);
				characterRotation.x = characterRotation.z = 0;
				model.rotation = Quaternion.Slerp(model.rotation, characterRotation, 10.0f * Time.deltaTime);
			}

            // set the movement of the player
			move = Vector3.MoveTowards(move, inputMoveXZ, ratio * runSpeed);
		}
		else
		{
            // if there is no input of keyboard, slowly speed down
			move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMgnitude) * runSpeed * ratio);


		}
		float speed = move.sqrMagnitude;
//		move.y = tempMoveY;
	}
}