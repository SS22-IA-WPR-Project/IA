using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schlaffner_Andre {
	public class proximity : MonoBehaviour
	{

		GameObject[] PlayerIds;
		float distance;

		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			Debug.Log(distance);
		}

		// Distance()-function returns the distance between Object a and b. Here we plan on using a Player Array/List and 
		// calculate the distance between 2 Players at [i] and [j] respectively.
		// Its still pretty much pseudo-code since we didnt implement a Playerlist yet
		float Distance()
        {
			for (int i = 0; i <= PlayerIds.Length; i++)
			{
				for (int j = 0; j <= PlayerIds.Length; j++)
				{
					if (i == j)
					{
						continue;
					}
					else
					{
						return distance = Vector3.Distance(PlayerIds[i].transform.position, PlayerIds[j].transform.position);
					}
				}
			}

			return 0.0f;
		}
	}
}