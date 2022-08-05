using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Studyrooms {
	public class PlayerManager : MonoBehaviour
	{

		[SerializeField] GameObject Player;
		Vector3[] SpawnPositions = new Vector3[4];

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
			SpawnPositions[0] = new Vector3(-8f, 0.5f, -16f);
			SpawnPositions[1] = new Vector3(-29f, 0.5f, -16f);
			SpawnPositions[2] = new Vector3(-28f, 0.5f, 53f);
			SpawnPositions[3] = new Vector3(-8f, 0.5f, 53f);
			//controller = Instantiate(Player,Vector3.zero, Quaternion.identity );
			//Debug.Log("has spawed");
			SREvents.sceneLoad.AddListener(CreateController);
		}

        void Start()
		{

		}

		//references the PlayerController script and assigns new Players a controller 
		void CreateController()
        {
			
			//Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();

			//Finds spawnpoint and instantiates the Player there
			controller = Instantiate(Player, Vector3.zero, Quaternion.identity);
			controller.transform.position = SpawnPositions[Random.Range(0, SpawnPositions.Length)];
			controller.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
			Debug.Log("has spawed");
		}

		
	}
}