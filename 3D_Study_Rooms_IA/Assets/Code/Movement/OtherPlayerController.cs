using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms {
	public class OtherPlayerController : MonoBehaviour
	{

		private CharacterController controller;
		Vec3 oldPosition;
		Vec3 overwriteData;
		private bool isGrounded;
		private Vector3 Velocity;

		// Start is called before the first frame update

		private void Awake()
        {
			SREvents.otherPlayerPos.AddListener(OverwritePositions);
        }

        void Start()
		{
			controller = gameObject.AddComponent<CharacterController>();
			controller.center = new Vector3(0f, 1f, 0f);
			oldPosition = new Vec3
			{
				_id = gameObject.name,
				x = transform.position.x,
				y = transform.position.y,
				z = transform.position.z,
				rot = transform.rotation.y
			};

			overwriteData = new Vec3
			{
				_id = "",
				x = 0f,
				y = 0f,
				z = 0f,
				rot = 0f
			};

		}

		// Update is called once per frame
		void Update()
		{
			/*isGrounded = controller.isGrounded;
			if (isGrounded && Velocity.y < 1f)
			{
				Velocity.y = 0.1f;
			}*/
			if (gameObject.name == overwriteData._id)
			{
				if (transform.position != new Vector3(overwriteData.x, overwriteData.y, overwriteData.z) || transform.rotation.y != overwriteData.rot)
				{
					/*oldPosition.x = controller.transform.position.x;
					oldPosition.y = controller.transform.position.y;
					oldPosition.z = controller.transform.position.z;
					controller.Move()*/
					transform.localPosition = new Vector3(overwriteData.x, overwriteData.y, overwriteData.z);
					transform.rotation = Quaternion.Euler(0f, overwriteData.rot, 0f);
					//transform.Rotate(new Vector3(0f,1f,0f),overwriteData.rot, Space.Self);
				}
			}

		}

		void OverwritePositions()
        {
			overwriteData = SREvents.otherPlayerPos.getVec3();
        }
	}
}
