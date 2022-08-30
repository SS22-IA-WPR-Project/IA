using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Studyrooms
{
    struct Avatar
    {
        public string _id;
        public int skin;
        public int bodybuild;
        public int backpack;
        public int helmet;
        public int glasses;
    }

    public class SceneSwitcher : MonoBehaviour
    {
        private void Awake()
        {
            SREvents.sceneLoadSignUpToCharUi.AddListener(signUpToCharGUI);
            SREvents.sceneLoadLogInToClass.AddListener(logInToClassroom);
        }

        public void charGUIToClassroom()
        {

            StartCoroutine(guiToClassLoad());
        }

        public void logInToClassroom()
        {
            StartCoroutine(logInToClassLoad());
        }
        
        public void signUpToCharGUI()
        {
            StartCoroutine(signUpToCharGUILoad());
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
            SREvents.sceneLoadClass.Invoke();
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

            if (SceneManager.GetSceneByName("Classroom").isLoaded)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Classroom"));
            }
            else
            {
                Debug.Log("scene not loaded");
            }

            // Unload the previous Scene
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("LogInGUI"));

            SREvents.sceneLoadLogInToClass.RemoveListener(logInToClassroom);
            SREvents.sceneLoadClass.Invoke();
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
            SREvents.sceneLoadSignUpToCharUi.RemoveListener(signUpToCharGUI);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
