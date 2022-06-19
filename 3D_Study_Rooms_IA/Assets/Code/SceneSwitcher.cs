using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    Scene characterGUI;
    Scene classroom;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        characterGUI = SceneManager.GetSceneByName("CharacterGUItest");
        classroom = SceneManager.GetSceneByName("Classroom");

        //GameObject[] findPlayer = characterGUI.GetRootGameObjects();
        /*foreach(GameObject tmpPlayer in findPlayer )
        {
            if(tmpPlayer.name == "player")
            {
                player = tmpPlayer ;
            }
        }*/
        player = gameObject;
        
    }

    public void charGUIToClassroom()
    {

        
        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Classroom", LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        //needs the extra methode, otherwise the wait won't work properlly
        asyncDone(asyncLoad);
        

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Classroom"));

        // Unload the previous Scene
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Classroom"));
       SceneManager.UnloadSceneAsync(0);
        
        
        Debug.Log(player.transform.position.x + " " + player.transform.position.y + " " + player.transform.position.z);
        player.transform.position = new Vector3(-5, 0.1f, 5);
        Debug.Log(player.transform.position.x + " " + player.transform.position.y + " " + player.transform.position.z);
        
    }

    //wail for async (un)load of scene
    IEnumerator asyncDone(AsyncOperation async)
    {
        while (async.isDone)
        {
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
