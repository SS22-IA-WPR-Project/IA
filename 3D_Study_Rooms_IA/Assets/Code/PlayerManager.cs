using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schlaffner_Andre {
	public class PlayerManager : MonoBehaviour
	{

		private GameObject Player;
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

		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			
		}

		//references the PlayerController script and assigns new Players a controller 
		void CreateController()
        {
			Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();

			//Finds spawnpoint and instantiates the Player there
			Instantiate(Player, spawnpoint.position, spawnpoint.rotation);
		}
	}
}