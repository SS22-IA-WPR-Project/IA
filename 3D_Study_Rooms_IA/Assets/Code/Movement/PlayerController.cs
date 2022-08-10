using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms
{
	public class PlayerController : MonoBehaviour
	{
        private GameObject PlayerPosition;
        private GameObject Player;
        [SerializeField] float sensitivity;
<<<<<<< Updated upstream
        Camera addCamera;
        //private string InputKey;
=======
        public GameObject orientation;
        private CharacterController controller;

        public float speed = 2f;
        float xRot;
        float yRot;
        private bool isGrounded;
        private Vector3 Velocity;

>>>>>>> Stashed changes
        // Start is called before the first frame update

        //TODO:
        //
        //Camera control for players (?)
        //
        //Emoticon Table reference
        //
        //interaction with other Players keys
        //
        //(voice) chat keys
        //
        //Whiteboard/text projecting keys
        //

        private void Awake()
        {
            
        }

        void Start()
        {
<<<<<<< Updated upstream
            addCamera = gameObject.AddComponent<Camera>();
            sensitivity = 0.5f;
=======
            controller = gameObject.AddComponent<CharacterController>();
            controller.center =new Vector3(0f, 1f, 0f);
            Cursor.lockState = CursorLockMode.Locked;
            orientation.AddComponent<Camera>();
            sensitivity = 150f;
>>>>>>> Stashed changes
        }

        // Update is called once per frame
        void Update()
        {
<<<<<<< Updated upstream
            //Takes the mouse movement and translates it onto the character, doesnt work quite right yet
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");
=======
            isGrounded = controller.isGrounded;
            if(isGrounded && Velocity.y < 1f)
            {
                Velocity.y = 1f;
            }

            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            yRot += mouseX;
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            transform.rotation = Quaternion.Euler(0f,yRot, 0f);
            orientation.transform.rotation = Quaternion.Euler(xRot, yRot, 0f);
>>>>>>> Stashed changes

            addCamera.transform.Rotate(transform.up * rotateHorizontal * sensitivity);
            addCamera.transform.Rotate(-transform.right * rotateVertical * sensitivity);


            //Player movement
            
            /*
             * doesnt work since you cant use multiple keys at the same time, also movement feels really weird with the switch keys
             * 
            switch (Input.inputString)
            {
                case "w":
                    transform.localPosition += Time.deltaTime * transform.forward * 2f;
                    break;
                case "a":
                    transform.Rotate(-transform.up * 0.5f);
                    break;
                case "s":
                    transform.localPosition += Time.deltaTime * -transform.forward * 2f;
                    break;
                case "d":
                    transform.Rotate(transform.up * 0.5f);
                    break;
                case "v":
                    //voice_chat key;
                    break;
                case "e":
                    //interaction with stuff
                    break;
                case "p":
                    //whiteboard shit
                    break;
            }
            */
            
            //Changed PlayerPosition.transform to transform so the script doesnt rely on a GameObject named "Player". 
            //also tried to limit movement in certain ways, but there are still improvements to do
            // added Inputs for whiteboard, voicechat and interactions but didnt implement those features yet

            if (Input.GetKey("up") || Input.GetKey("w"))
            {
<<<<<<< Updated upstream
                transform.localPosition += Time.deltaTime * transform.forward * 2f;
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-transform.up * 0.5f);
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.localPosition += Time.deltaTime * -transform.forward * 2f;
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(transform.up * 0.5f);
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
=======
                controller.Move(Time.deltaTime * transform.forward * speed);
                //rb.MovePosition(Time.deltaTime * transform.forward * speed)
                //rb.position = new Vector3(rb.position.x, 0f, rb.position.z);
               // transform.localPosition += Time.deltaTime * transform.forward * speed;
               // transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                controller.Move(Time.deltaTime * -transform.right * speed);
               // transform.localPosition += Time.deltaTime * -transform.right * speed;
               // transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                controller.Move(Time.deltaTime * -transform.forward * speed);
               // transform.localPosition += Time.deltaTime * -transform.forward * speed;
               // transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                controller.Move(Time.deltaTime * transform.right * speed);
                //transform.localPosition += Time.deltaTime * transform.right * speed;
                //transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
>>>>>>> Stashed changes
            }
            if (Input.GetKey(KeyCode.V))
            {
                //voice chat stuff
            }
            if (Input.GetKey(KeyCode.E))
            {
                //interaction with Stuff
            }
            if (Input.GetKey(KeyCode.P))
            {
                //whiteboard stuff
            }
            
        }
    }
}