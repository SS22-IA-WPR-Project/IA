using Firesplash.UnityAssets.SocketIO;
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
        private Camera camera;
        private CharacterController controller;

        public float speed = 2f;
        float xRot;
        float yRot;
        private bool isGrounded;
        private Vector3 Velocity;

        // Start is called before the first frame update
        void Start()
        {
            controller = gameObject.AddComponent<CharacterController>();
            controller.center = new Vector3(0f, 1f, 0f);
            Cursor.lockState = CursorLockMode.Locked;
            orientation.AddComponent<Camera>();
            camera = orientation.GetComponent<Camera>();
            camera.enabled = true;
            sensitivity = 150f;

            orientation.GetComponent<Camera>().gameObject.name = "Camera " + PlayerPrefs.GetString("playerID");
        }

        // Update is called once per frame
        void Update()
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && Velocity.y < 1f)
            {
                Velocity.y = 0.1f;
            }

            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            yRot += mouseX;
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 52f);

            transform.rotation = Quaternion.Euler(0f, yRot, 0f);
            orientation.transform.rotation = Quaternion.Euler(xRot, yRot, 0f);

            //Player movement
            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                controller.Move(Time.deltaTime * transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                controller.Move(Time.deltaTime * -transform.right * speed);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                controller.Move(Time.deltaTime * -transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                controller.Move(Time.deltaTime * transform.right * speed);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speed = 5f;
            }
            else speed = 2f;
            
            if (Input.GetMouseButtonDown(0))
            { 
                Ray ray = orientation.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 50.0f))
                {
                    if (hit.transform.name.Contains("console"))
                    {                    
                        SREvents.sceneLoadClassToGUI.Invoke();
                    }
                    if (hit.transform.name.Contains("decorative_table_glass"))
                    {
                        PlayerPrefs.SetInt("tabelCamNumber",int.Parse(hit.transform.name.Substring(24, 1)) );
                        PlayerPrefs.SetString("playerCameraID", orientation.GetComponent<Camera>().gameObject.name);

                        SREvents.joinTable.Invoke();
                    }
                }
            }

            //kills Player
            if (Input.GetKey(KeyCode.K))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
