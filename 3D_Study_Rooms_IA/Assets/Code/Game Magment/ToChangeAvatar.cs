using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Studyrooms { 
    public class ToChangeAvatar : MonoBehaviour
    {
        
       
        GameObject activeplayer;
        public Camera AvatarCamera0;

        public Button next;
        public Button back;
        public Button save;
        public Button leave;

        public Toggle backpack;
        public Toggle helmet;

        public Slider bodybuild;
        public Dropdown glasses;


        private void Awake()
        {
            SREvents.sceneLoadClassToGUI.AddListener(classToCharGUI);
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }
        public void classToCharGUI()
        {
            next.GetComponent<Image>().raycastTarget = true;
            back.GetComponent<Image>().raycastTarget = true;
            save.GetComponent<Image>().raycastTarget = true;
            leave.GetComponent<Image>().raycastTarget = true;
            glasses.GetComponent<Image>().raycastTarget = true;

            backpack.GetComponentInChildren<Image>().raycastTarget = true;
            helmet.GetComponentInChildren<Image>().raycastTarget = true;
            bodybuild.GetComponentInChildren<Image>().raycastTarget = true;

            //changingRoom = int.Parse(SREvents.sceneLoadClassToGUI.GetId());
            //StartCoroutine(classToGUILoad());
            activeplayer = GameObject.Find(PlayerPrefs.GetString("playerID"));
            activeplayer.GetComponent<PlayerController>().enabled = false;
            activeplayer.GetComponentInChildren<Camera>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            AvatarCamera0.enabled = true;
            //switch (changingRoom){
            //    case 0:
                    
            //        break;
            //    case 1:
            //        AvatarCamera1.enabled = true;
            //        break;
            //    case 2:
            //        AvatarCamera2.enabled = true;
            //        break;
            //    case 3:
            //        AvatarCamera3.enabled = true;
            //        break;

            //}

            //if (!running)
            //{
            //    StopCoroutine(classToGUILoad());
            //    Debug.Log("stoped");
            //}

        }


        IEnumerator classToGUILoad()
        {
            
            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CharacterGUItest", LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone)
            {
                 yield return null;
            }

            if (SceneManager.GetSceneByName("CharacterGUItest").isLoaded)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("CharacterGUItest"));
            }
            else
            {
                Debug.Log("scene not loaded");
            }

            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Classroom"));
            Cursor.lockState = CursorLockMode.None;
            
            SREvents.sceneLoadClassToGUI.RemoveListener(classToCharGUI);
        }

        public void leaveChangingRoom()
        {
            AvatarCamera0.enabled = false;
            
            next.GetComponent<Image>().raycastTarget = false;
            back.GetComponent<Image>().raycastTarget = false;
            save.GetComponent<Image>().raycastTarget = false;
            leave.GetComponent<Image>().raycastTarget = false;
            glasses.GetComponent<Image>().raycastTarget = false;

            backpack.GetComponentInChildren<Image>().raycastTarget = false;
            helmet.GetComponentInChildren<Image>().raycastTarget = false;
            bodybuild.GetComponentInChildren<Image>().raycastTarget = false;

            SREvents.sceneLoadClass.Invoke();
            SREvents.reloadAvatar.Invoke();
            //activeplayer.GetComponentInChildren<Camera>().enabled = true;
            //switch (changingRoom)
            //{
            //    case 0:
            //        AvatarCamera0.enabled = false;
            //        break;
            //    case 1:
            //        AvatarCamera1.enabled = false;
            //        break;
            //    case 2:
            //        AvatarCamera2.enabled = false;
            //        break;
            //    case 3:
            //        AvatarCamera3.enabled = false;
            //        break;

            //}

        }
        
    }
}
