using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms {
	public class PlayerClient : MonoBehaviour
	{
		// Start is called before the first frame update
		Vector3 GetPosition()
        {
			return transform.position;
        }
	}
}