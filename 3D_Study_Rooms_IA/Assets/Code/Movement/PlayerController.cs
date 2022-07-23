using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms
{
	public class PlayerController : MonoBehaviour
	{
        [SerializeField] float sensitivity;
        public GameObject orientation;

        float xRot;
        float yRot;

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

        private void Awake()
        {
            
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            orientation.AddComponent<Camera>();
            sensitivity = 150f;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            yRot += mouseX;
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            transform.rotation = Quaternion.Euler(0f,yRot, 0f);
            orientation.transform.rotation = Quaternion.Euler(xRot, yRot, 0f);



            //Player movement
            
            //Changed PlayerPosition.transform to transform so the script doesnt rely on a GameObject named "Player". 
            //also tried to limit movement in certain ways, but there are still improvements to do
            // added Inputs for whiteboard, voicechat and interactions but didnt implement those features yet

            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                transform.localPosition += Time.deltaTime * transform.forward * 2f;
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localPosition += Time.deltaTime * -transform.right * 2f;
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.localPosition += Time.deltaTime * -transform.forward * 2f;
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.localPosition += Time.deltaTime * transform.right * 2f;
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) 
            { 
                //run boi run
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