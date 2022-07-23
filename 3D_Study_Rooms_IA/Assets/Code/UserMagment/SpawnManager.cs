using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms
{
	public class SpawnManager : MonoBehaviour
	{
		//public static SpawnManager Instance;

		GameObject[] spawnpoints;
        int i = 0;

        //gets all  Spawnpoints and saves them in the spawnpoints array
        private void Awake()
        {

			//Instance = this;
            foreach(Transform pos in transform.GetComponentInChildren<Transform>())
            {
                spawnpoints[i] = pos.gameObject;
                i++;
            }
			
        }

        public void Start()
        {
         
        }

        //randomly assigns one spawnpoint to the Character
        public Transform GetSpawnpoint()
        {
			return spawnpoints[Random.Range(0,spawnpoints.Length)].transform;
        }
	}
}