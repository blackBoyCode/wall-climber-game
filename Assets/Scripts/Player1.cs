using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour {
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

    public GameObject Banana;
    public GameObject Pineapple;
    public GameObject Present;
    public GameObject Teddybear;

    private GameObject[] objects = new GameObject[4];

    public AudioClip banana;
    public AudioClip pineapple;
    public AudioClip present;
    public AudioClip teddybear;
    public AudioClip collect;
    public AudioClip platform;
    public AudioClip final;

    public AudioSource audiosource;

    bool playerDeath = false;

    public GameObject checkPoint1;
    public GameObject checkPoint2;
    public GameObject checkPoint3;

    public CheckPoints checkPoint;
    //   public GameObject SpawnCube;

    void Start () {

        gotGun = false;
		move = Vector3.zero;
		myTransform = transform;
		cc = GetComponent <CharacterController> ();
		cameraTransform = Camera.main.transform;
		cameraParentTransform = cameraTransform.parent;
	}

	void Update () {

        if (!playerDeath)
        {
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
                if (Input.GetKeyDown(KeyCode.Space)&& velocity < -0.1f)
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
                    if (velocity <= 0)
                        gravity = 1.0f;
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    gravity = 20.0f;
                }

                velocity -= (gravity * Time.deltaTime);

                //instantiate object if shooting

                objects[0] = Banana;
                objects[1] = Pineapple;
                objects[2] = Present;
                objects[3] = Teddybear;

                if (Input.GetMouseButtonDown(0)) // &&gotGun
                {
                    //want a random object to be chosen
                    int random = Random.Range(0, 4);
                    //if we choose banana play sound
                    if (random == 0) audiosource.clip = banana;
                    //if we choose pineapple play sound
                    if (random == 1) audiosource.clip = pineapple;
                    //if we choose present play sound
                    if (random == 2) audiosource.clip = present;
                    //if we choose teddybear play sound
                    if (random == 3) audiosource.clip = teddybear;

                    Instantiate(objects[random], Camera.main.transform.position + Camera.main.transform.forward * 8.0f, Quaternion.identity);
                    audiosource.Play();
                }

            }

            move.y = velocity;
            cc.Move(move * Time.deltaTime);

            cameraParentTransform.position = myTransform.position;
            mouseMove += new Vector3(-Input.GetAxisRaw("Mouse Y") * mouseSensitivity, Input.GetAxisRaw("Mouse X") * mouseSensitivity, 0);

            cameraParentTransform.localEulerAngles = mouseMove;
        }
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "gun") {
            gotGun =true;
        }

        if(other.gameObject.tag == "Diamond")
        {

            Destroy(other.gameObject);
            //add 1 to the diamond count
            ScoreScript.gemAmount = ScoreScript.gemAmount + 1;
            audiosource.clip = collect;
            audiosource.Play();
        }
        if(other.gameObject.tag == "PlatformSound")
        {
            Destroy(other.gameObject);
            audiosource.clip = platform;
            audiosource.Play();
        }

        if (other.gameObject.tag == "Finally")
        {
            Destroy(other.gameObject);
            audiosource.clip = final;
            audiosource.Play();
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(cursor.gameObject);
            playerDeath = true;
        }


        if (other.CompareTag("DeadZone"))
        {
            cc.enabled = true;
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

    private void OnGUI()
    {
        if (playerDeath)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 100), "Do you want to continue?"))
            {
                SceneManager.LoadScene("game");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 100), "Do you want to quit?"))
            {
                Application.Quit();
            }
        }
    }

}
