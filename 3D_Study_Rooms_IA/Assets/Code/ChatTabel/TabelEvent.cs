using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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

        public Canvas canvas01;
        public Canvas canvas02;
        public Canvas canvas03;
        public Canvas canvas04;
        public Canvas canvas05;
        public Canvas canvas06;




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
                        canvas01.enabled = true;
                        canvas02.enabled = false;
                        canvas03.enabled = false;
                        canvas04.enabled = false;
                        canvas05.enabled = false;
                        canvas06.enabled = false;

                        Debug.Log("1");
                        playerCam.enabled = false;
                        cam1.enabled = true;
                        
                        break;
                    }
                case 2:
                    {
                        canvas01.enabled = false;
                        canvas02.enabled = true;
                        canvas03.enabled = false;
                        canvas04.enabled = false;
                        canvas05.enabled = false;
                        canvas06.enabled = false;


                        Debug.Log("2");
                        playerCam.enabled = false;
                        cam2.enabled = true;
                        
                        break;
                    }
                case 3:
                    {
                        canvas01.enabled = false;
                        canvas02.enabled = false;
                        canvas03.enabled = true;
                        canvas04.enabled = false;
                        canvas05.enabled = false;
                        canvas06.enabled = false;

                        Debug.Log("3");
                        playerCam.enabled = false;
                        cam3.enabled = true;
                        
                        break;
                    }
                case 4:
                    {
                        canvas01.enabled = false;
                        canvas02.enabled = false;
                        canvas03.enabled = false;
                        canvas04.enabled = true;
                        canvas05.enabled = false;
                        canvas06.enabled = false;

                        Debug.Log("4");
                        playerCam.enabled = false;
                        cam4.enabled = true;
                        
                        break;
                    }
                case 5:
                    {
                        canvas01.enabled = false;
                        canvas02.enabled = false;
                        canvas03.enabled = false;
                        canvas04.enabled = false;
                        canvas05.enabled = true;
                        canvas06.enabled = false;

                        Debug.Log("5");
                        playerCam.enabled = false;
                        cam5.enabled = true;
                        
                        break;
                    }
                case 6:
                    {
                        canvas01.enabled = false;
                        canvas02.enabled = false;
                        canvas03.enabled = false;
                        canvas04.enabled = false;
                        canvas05.enabled = false;
                        canvas06.enabled = true;

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

            canvas01.enabled = false;
            canvas02.enabled = false;
            canvas03.enabled = false;
            canvas04.enabled = false;
            canvas05.enabled = false;
            canvas06.enabled = false;

            //movemendSkript = GameObject.Find("playerInGame");
            movemendSkript.GetComponent<PlayerController>().enabled = true;
            
            Cursor.lockState = CursorLockMode.Locked;


        }

    }
}
