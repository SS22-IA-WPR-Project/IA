using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms {
	public class PlayerManager : MonoBehaviour
	{

		[SerializeField] GameObject Player;

		GameObject controller;
        // Start is called before the first frame update
        //
        //TODO:
        //
        //interaction with other players
        //
        //voice chat
        //
        //GUI
        //
        //something with the emoticon table
        //
        //Whiteboard reference

        private void Awake()
        {
			//controller = Instantiate(Player,Vector3.zero, Quaternion.identity );
			//Debug.Log("has spawed");
			SREvents.sceneLoad.AddListener(CreateController);
		}

        void Start()
		{
			//controller = Instantiate(Player, Vector3.zero, Quaternion.identity);
			
			//controller = CreateController();
		}

		// Update is called once per frame
		void Update()
		{
			
		}

		//references the PlayerController script and assigns new Players a controller 
		void CreateController()
        {
			//Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
			Debug.Log("has spawed");
			//Finds spawnpoint and instantiates the Player there
			//controller.transform.position = spawnpoint.position;
			//controller.transform.rotation = spawnpoint.rotation;
			controller = Instantiate(Player, Vector3.zero, Quaternion.identity);
			controller.transform.position = new Vector3(-16f, 0f, -8f);
			controller.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

			//return controller;
		}
	}
}