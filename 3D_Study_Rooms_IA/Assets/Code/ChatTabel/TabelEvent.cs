using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Studyrooms
{
    public class TabelEvent : MonoBehaviour
    {

        public Camera cam1;
        public Camera cam2;
        public Camera cam3;
        public Camera cam4;
        public Camera cam5;
        public Camera cam6;

        private Camera playerCam;
        private GameObject movemendSkript;
        

        private void Awake()
        {
            SREvents.joinTable.AddListener(toTable);
        }

        public void toTable()
        {

           int tabelNumber = PlayerPrefs.GetInt("tabelCamNumber");

            Debug.Log("nach get"+tabelNumber);

           playerCam = GameObject.Find(PlayerPrefs.GetString("playerCameraID")).GetComponent<Camera>(); 

           movemendSkript = GameObject.Find(PlayerPrefs.GetString("playerID"));
           movemendSkript.GetComponent<PlayerController>().enabled = false;
            
            
            Cursor.lockState = CursorLockMode.None;

            switch (tabelNumber)
            {

                case 1:
                    {
                        Debug.Log("1");
                        playerCam.enabled = false;
                        cam1.enabled = true;
                        
                        break;
                    }
                case 2:
                    {
                        Debug.Log("2");
                        playerCam.enabled = false;
                        cam2.enabled = true;
                        
                        break;
                    }
                case 3:
                    {
                        Debug.Log("3");
                        playerCam.enabled = false;
                        cam3.enabled = true;
                        
                        break;
                    }
                case 4:
                    {
                        Debug.Log("4");
                        playerCam.enabled = false;
                        cam4.enabled = true;
                        
                        break;
                    }
                case 5:
                    {
                        Debug.Log("5");
                        playerCam.enabled = false;
                        cam5.enabled = true;
                        
                        break;
                    }
                case 6:
                    {
                        Debug.Log("6");
                        playerCam.enabled = false;
                        cam6.enabled = true;
                        
                        break;
                    }


            }

        }

        public void fromTable()
        {
            playerCam.enabled = true; 

            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = false;
            cam5.enabled = false;
            cam6.enabled = false;

            //movemendSkript = GameObject.Find("playerInGame");
            movemendSkript.GetComponent<PlayerController>().enabled = true;
            
            Cursor.lockState = CursorLockMode.Locked;


        }

    }
}
