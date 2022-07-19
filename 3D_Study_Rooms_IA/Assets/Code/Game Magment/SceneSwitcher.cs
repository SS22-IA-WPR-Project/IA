using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Studyrooms
{
    public class SceneSwitcher : MonoBehaviour
    {
        Scene characterGUI;
        Scene classroom;
        public GameObject thisPlayer;
        GameObject orgPlayer;

        // Start is called before the first frame update
        void Start()
        {
            characterGUI = SceneManager.GetSceneByName("CharacterGUItest");
            classroom = SceneManager.GetSceneByName("Classroom");

        }

        public void charGUIToClassroom()
        {

            StartCoroutine(guiToClassLoad());

            //thisPlayer = GameObject.Instantiate(thisPlayer, new Vector3(-5, 0.1f, 5), thisPlayer.transform.rotation);
            thisPlayer.transform.position = new Vector3(5, 0.1f, 5);
            Debug.Log(thisPlayer.transform.position.x);

            StopCoroutine(guiToClassLoad());

        }

        public void logInToClassroom()
        {
            var cor = StartCoroutine(logInToClassLoad());


            //StopCoroutine(logInToClassLoad());

            if (SceneManager.GetSceneByName("LogInGUI").isLoaded)
            {
                Debug.Log("scene is still loaded");
            }
            
        }

        public void signUpToCharGUI()
        {
            StartCoroutine(signUpToCharGUILoad());


            StopCoroutine(signUpToCharGUILoad());
        }

        IEnumerator guiToClassLoad()
        {
            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Classroom", LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            if (SceneManager.GetSceneByName("Classroom").isLoaded)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Classroom"));
            }
            else
            {
                Debug.Log("scene not loaded");
            }

            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("CharacterGUItest"));
        }

        IEnumerator logInToClassLoad()
        {

            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Classroom", LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log("test1");
            if (SceneManager.GetSceneByName("Classroom").isLoaded)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Classroom"));
            }
            else
            {
                Debug.Log("scene not loaded");
            }
            Debug.Log("test2");
            // Unload the previous Scene
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("LogInGUI"));
            Debug.Log("test3");
            /*
            while (!asyncUnload.isDone)
            {
                yield return null;
            }*/
            
            Debug.Log("test4");
            SREvents.sceneLoad.Invoke();

        }

        IEnumerator signUpToCharGUILoad()
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
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("LogInGUI"));


        }

    }
}
