using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Test für new Unity
namespace Schlaffner_Andre {
	public class SpawnManager : MonoBehaviour
	{
		public static SpawnManager Instance;

		SpawnPoint spawnpoint;

        private void Awake()
        {
			Instance = this;
			spawnpoint = GetComponentInChildren<SpawnPoint>();
        }

		public Transform GetSpawnpoint()
        {
			return spawnpoint.transform;
        }
	}
}