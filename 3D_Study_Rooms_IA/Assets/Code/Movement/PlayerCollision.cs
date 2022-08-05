
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
        private void OnCollisionEnter(Collision collision)
        {   
            Debug.Log("Enter");
            Debug.Log(collision.collider.name);
           // movement.speed = 0f;
            Debug.Log(movement.speed);
            CollidedWith = collision.collider.gameObject;

           /* CollidedWithRb = CollidedWith.GetComponent<Rigidbody>();
            CollidedWithRb.freezeRotation = true;
            CollidedWithRb.constraints = RigidbodyConstraints.FreezePosition;
           */
           // rb.isKinematic = true;

            if (collision.gameObject.activeInHierarchy)
            {
                movement.speed = 0f;
                //movement.enabled = false;
                rb.velocity = Vector3.zero;
                collision.gameObject.transform.position = collision.gameObject.transform.localPosition;
                Debug.Log(collision.gameObject.transform.position);
            }
           // transform.localPosition += Time.deltaTime * transform.forward * 0f;
           //transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
        }

        private void OnCollisionStay(Collision collision)
        {
            Debug.Log("Stay");
            collision.gameObject.transform.position = collision.gameObject.transform.localPosition;
            //movement.speed = 2f;
        }

        private void OnCollisionExit(Collision collision)
        {
            Debug.Log("Exit");
            movement.speed = 2f;
        }
    }
}