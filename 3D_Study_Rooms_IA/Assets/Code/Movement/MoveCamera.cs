using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schlaffner_Andre {
	public class MoveCamera : MonoBehaviour
	{
		public Transform cameraPosition;

		// Update is called once per frame
		void Update()
		{
			transform.position = cameraPosition.position;
		}
	}
}