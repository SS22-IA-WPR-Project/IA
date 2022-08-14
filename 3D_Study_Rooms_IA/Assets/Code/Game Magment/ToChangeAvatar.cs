using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Studyrooms { 
    public class ToChangeAvatar : MonoBehaviour
    {
        
        bool running;
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
            
            StartCoroutine(classToGUILoad());

            if (!running)
            {
                StopCoroutine(classToGUILoad());
                Debug.Log("stoped");
            }

        }


        IEnumerator classToGUILoad()
        {
            running = true;
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
            running = false;
            SREvents.sceneLoadClassToGUI.RemoveListener(classToCharGUI);
        }
        
    }
}
