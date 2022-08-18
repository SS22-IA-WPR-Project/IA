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
            //SREvents.exitTable.AddListener(fromTable);
           


        }

        public void toTable()
        {

           int tabelNumber = PlayerPrefs.GetInt("tabelCamNumber"); // tabel number (test)
           playerCam = GameObject.Find(PlayerPrefs.GetString("playerCameraID")).GetComponent<Camera>(); // cam of player (test)

            movemendSkript = GameObject.FindWithTag("playerInGame");
            movemendSkript.GetComponent<PlayerController>().enabled = false;// disable moovment of player (test)
            
            
            Cursor.lockState = CursorLockMode.None;

            switch (tabelNumber)
            {

                case 1:
                    {
                        playerCam.enabled = false;
                        cam1.enabled = true;
                        
                        break;
                    }
                case 2:
                    {
                        playerCam.enabled = false;
                        cam2.enabled = true;
                        
                        break;
                    }
                case 3:
                    {
                        playerCam.enabled = false;
                        cam3.enabled = true;
                        
                        break;
                    }
                case 4:
                    {
                        playerCam.enabled = false;
                        cam4.enabled = true;
                        
                        break;
                    }
                case 5:
                    {
                        playerCam.enabled = false;
                        cam5.enabled = true;
                        
                        break;
                    }
                case 6:
                    {
                        playerCam.enabled = false;
                        cam6.enabled = true;
                        
                        break;
                    }


            }

        }

        public void fromTable()
        {
            playerCam.enabled = true; //back to player Cam

            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = false;
            cam5.enabled = false;
            cam6.enabled = false;

            movemendSkript = GameObject.FindWithTag("playerInGame");
            movemendSkript.GetComponent<PlayerController>().enabled = true;// enable moovment of player (test)



        }

    }
}
