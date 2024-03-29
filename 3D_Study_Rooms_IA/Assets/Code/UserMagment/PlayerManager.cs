using UnityEngine;

namespace Studyrooms {
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] GameObject Player;
		Vector3[] SpawnPositions = new Vector3[4];

		GameObject controller;

        private void Awake()
        {
			SpawnPositions[0] = new Vector3(-8f, 0.1f, -16f);
			SpawnPositions[1] = new Vector3(-29f, 0.1f, -16f);
			SpawnPositions[2] = new Vector3(-28f, 0.1f, 53f);
			SpawnPositions[3] = new Vector3(-8f, 0.1f, 53f);

			SREvents.sceneLoadClass.AddListener(CreateController);
		}

		//references the PlayerController script and assigns new Players a controller
		void CreateController()
        {
			//Finds spawnpoint and instantiates the Player there
			GameObject activeplayer = GameObject.Find(PlayerPrefs.GetString("playerID"));
			
			if (activeplayer != null){
				controller = activeplayer;
				Debug.Log(activeplayer.name);
				activeplayer.GetComponent<PlayerController>().enabled = true;
				activeplayer.GetComponentInChildren<Camera>().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
			}
            else
            {
				int spawner = Random.Range(0, SpawnPositions.Length);
                controller = Instantiate(Player, Vector3.zero, Quaternion.identity);
				controller.name = PlayerPrefs.GetString("playerID");
				controller.transform.position = SpawnPositions[spawner];
				if (spawner == 0 || spawner == 1)
				{
					controller.transform.Rotate(0f, 0f, 0f);
					Debug.Log("spawnroom abfrage geht rein " + spawner);
				}
				else
				{
					controller.transform.Rotate(0f, 179.9f, 0f);
					Debug.Log("spawnroom geht in else " + spawner);
				}		
            }
            if (!controller.GetComponentInChildren<PlayerAvatar>().enabled)
            {				
				controller.GetComponentInChildren<PlayerAvatar>().enabled = true;
			}			
			SREvents.getUserAvatar.Invoke();
		}
    }
}
