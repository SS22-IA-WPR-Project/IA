
using UnityEngine;

namespace Studyrooms{
	public class PlayerCollision : MonoBehaviour
	{
        public Rigidbody rb;
        public PlayerController movement;
        private GameObject CollidedWith;
        private Rigidbody CollidedWithRb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("TriggerEnter");
            movement.speed = 0f;
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("TriggerExit");
            movement.speed = 2f;
        }

        private void OnCollisionEnter(Collision collision)
        {   
            Debug.Log("Enter");
            Debug.Log(collision.collider.name);
           // movement.speed = 0f;
            CollidedWith = collision.collider.gameObject;

           /* CollidedWithRb = CollidedWith.GetComponent<Rigidbody>();
            CollidedWithRb.freezeRotation = true;
            CollidedWithRb.constraints = RigidbodyConstraints.FreezePosition;
           */
           // rb.isKinematic = true;

           movement.speed = 0f;
            Debug.Log(movement.speed);

            //movement.enabled = false;
            rb.velocity = Vector3.zero;
           //Debug.Log(collision.gameObject.transform.position);
            
           // transform.localPosition += Time.deltaTime * transform.forward * 0f;
           //transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
        }

        private void OnCollisionStay(Collision collision)
        {
            rb.velocity = Vector3.zero;
            Debug.Log("Stay");
            CollidedWith.transform.position = CollidedWith.transform.localPosition; 
            movement.speed = 0f;
            Debug.Log(movement.speed);
        }

        private void OnCollisionExit(Collision collision)
        {
            Debug.Log("Exit");
            movement.speed = 2f;
            Debug.Log(movement.speed);
        }
    }
}