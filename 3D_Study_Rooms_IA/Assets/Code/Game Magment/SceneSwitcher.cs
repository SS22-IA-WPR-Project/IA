using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


namespace Studyrooms
{

    
    public class SceneSwitcher : MonoBehaviour
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

        public GameObject thisPlayer;
       
        private void Awake()
        {
            SREvents.sceneLoadSignUpToCharUi.AddListener(signUpToCharGUI);
            SREvents.sceneLoadLogInToClass.AddListener(logInToClassroom);
            SREvents.sceneLoadClassToGUI.AddListener(classToCharGUI);
            Debug.Log("listeners added");
        }

        // Start is called before the first frame update
        void Start()
        {
           
        }

        public void doneAvatar()
        {
            StartCoroutine(sendAvatarData());
        }

        public void classToCharGUI()
        {
            StartCoroutine(classToGUILoad());
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
            Debug.Log("start switch");
            StartCoroutine(signUpToCharGUILoad());
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

            SREvents.sceneLoad.Invoke();
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
            Debug.Log("switching");
            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("LogInGUI"));

        }

        IEnumerator sendAvatarData()
        { 
            var avatar = new Avatar
            {
                _id = PlayerPrefs.GetString("playerID"),
                skin = PlayerPrefs.GetInt("skin"),
                bodybuild = (int)PlayerPrefs.GetFloat("bodyValue"),
                backpack = PlayerPrefs.GetInt("backpack"),
                helmet = PlayerPrefs.GetInt("helmet"),
                glasses = PlayerPrefs.GetInt("glasses")

            };

            var request = LoginClient.Post("user/create", JsonUtility.ToJson(avatar));

            yield return request.SendWebRequest();

            Debug.Log("callback-data: " + Encoding.Default.GetString(request.downloadHandler.data));

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);

            }
        }
    }
}
