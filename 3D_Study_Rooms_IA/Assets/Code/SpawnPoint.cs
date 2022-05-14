using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schlaffner_Andre {
	public class SpawnPoint : MonoBehaviour
	{
		// Start is called before the first frame update
		[SerializeField] GameObject graphics;

        void Awake()
        {
            graphics.SetActive(false);
        }

    }
}