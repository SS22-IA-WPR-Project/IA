using Firesplash.UnityAssets.SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if HAS_JSON_NET
using Newtonsoft.Json;
#endif

namespace Studyrooms
{
    public class PlayerController : MonoBehaviour
    {

        public SocketIOCommunicator socCom;

        [SerializeField] float sensitivity;
        public GameObject orientation;
        private CharacterController controller;

        public float speed = 2f;
        float xRot;
        float yRot;
        private bool isGrounded;
        private Vector3 Velocity;

        // Start is called before the first frame update

        //TODO:
        //Emoticon Table reference
        //
        //interaction with other Players keys
        //
        //(voice) chat keys
        //
        //Whiteboard/text projecting keys
        //

        void Start()
        {
            controller = gameObject.AddComponent<CharacterController>();
            controller.center = new Vector3(0f, 1f, 0f);
            Cursor.lockState = CursorLockMode.Locked;
            orientation.AddComponent<Camera>();
            sensitivity = 150f;

           /* socCom.Instance.On("connection", (string data) =>
            {
                Debug.Log("Connection made!");

                socCom.Instance.Emit("Hello there");
            });

            socCom.Instance.On("user:coordinate", (string data) =>
            {
                Debug.Log("get hier rein");
                socCom.Instance.Emit("Hello there");
                //socCom.Instance.Emit("user:coordinate", JsonUtility.ToJson(Pos), true);
            });

            socCom.Instance.Connect("http://25.59.191.68:8080", false);*/
        }

        // Update is called once per frame
        void Update()
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && Velocity.y < 1f)
            {
                Velocity.y = 1f;
            }

            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            yRot += mouseX;
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 52f);

            transform.rotation = Quaternion.Euler(0f, yRot, 0f);
            orientation.transform.rotation = Quaternion.Euler(xRot, yRot, 0f);



            //Player movement

            // added Inputs for whiteboard, voicechat and interactions but didnt implement those features yet

            if (Input.GetKey("up") || Input.GetKey("w"))
            {
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
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speed = 5f;
            }
            else speed = 2f;
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

            if (Input.GetMouseButtonDown(0))
            { // if left button pressed...
                Ray ray = orientation.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 50.0f))
                {
                    //Debug.Log(hit.transform.name);
                    if (hit.transform.name == "console (2)")
                    {
                        Debug.Log("hit console");
                        SREvents.sceneLoadClassToGUI.Invoke();
                    }
                    if (hit.transform.name.Contains("decorative_table_glass"))
                    {
                        Debug.Log("User " + PlayerPrefs.GetString("emailID") + " wants to join Table " + hit.transform.name.Substring(24, 1));
                    }

                }
            }
            //kills Player
            if (Input.GetKey(KeyCode.K))
            {
                Destroy(this.gameObject);
            }


           /* var Pos = new Vec3
            {
                _id = PlayerPrefs.GetString("playerID"),
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z
            };

            socCom.Instance.On("user:coordinate", (string data) =>
            {
                Debug.Log("get hier rein");
                socCom.Instance.Emit("Hello there");
                //socCom.Instance.Emit("user:coordinate", JsonUtility.ToJson(Pos), true);
            });

            socCom.Instance.Connect("http://25.59.191.68:8080", false);*/
        }

       /* private IEnumerator sendPos()
        {
           var Pos = new Vec3
            {
                _id = PlayerPrefs.GetString("emailID"),
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z
            };

            var request = LoginClient.Post("25.59.191.68:8080", JsonUtility.ToJson(Pos));
            yield return request.SendWebRequest();
        }

        /*private IEnumerator getPos()
        {
            //var get = LoginClient.Get("", JsonUtility.FromJson(""));

           // yield return get;
        }*/
    }
}
