using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms
{
	public class IsCollided : MonoBehaviour
	{
        private void OnCollisionStay(Collision collision)
        {
            gameObject.transform.position = gameObject.transform.position;
           // rb.velocity = Vector3.zero;
            Debug.Log("isCollided");
        }
    }
}