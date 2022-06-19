using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schlaffner_Andre {
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
			controller = Instantiate(Player,Vector3.zero, Quaternion.identity );
		}

        void Start()
		{
			controller = CreateController();
		}

		// Update is called once per frame
		void Update()
		{
			
		}

		//references the PlayerController script and assigns new Players a controller 
		GameObject CreateController()
        {
			Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();

			//Finds spawnpoint and instantiates the Player there
			controller.transform.position = spawnpoint.position;
			controller.transform.rotation = spawnpoint.rotation;

			return controller;
		}
	}
}