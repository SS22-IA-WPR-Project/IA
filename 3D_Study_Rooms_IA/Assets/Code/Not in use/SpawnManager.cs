using UnityEngine;

namespace Studyrooms
{
	public class SpawnManager : MonoBehaviour
	{
		GameObject[] spawnpoints;
        int i = 0;

        //gets all  Spawnpoints and saves them in the spawnpoints array
        private void Awake()
        {
            foreach(Transform pos in transform.GetComponentInChildren<Transform>())
            {
                spawnpoints[i] = pos.gameObject;
                i++;
            }		
        }

        //randomly assigns one spawnpoint to the Character
        public Transform GetSpawnpoint()
        {
			return spawnpoints[Random.Range(0,spawnpoints.Length)].transform;
        }
	}
}