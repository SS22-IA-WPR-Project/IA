using UnityEngine;

namespace Studyrooms {
	public class OtherPlayerController : MonoBehaviour
	{
		private CharacterController controller;
		Vec3 overwriteData;

		private void Awake()
        {
			SREvents.otherPlayerPos.AddListener(OverwritePositions);
        }

		// Start is called before the first frame update
		void Start()
		{
			controller = gameObject.AddComponent<CharacterController>();
			controller.center = new Vector3(0f, 1f, 0f);

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
			if (gameObject.name == overwriteData._id)
			{
				if (transform.position != new Vector3(overwriteData.x, overwriteData.y, overwriteData.z) || transform.rotation.y != overwriteData.rot)
				{
					transform.localPosition = new Vector3(overwriteData.x, overwriteData.y, overwriteData.z);
					transform.rotation = Quaternion.Euler(0f, overwriteData.rot, 0f);
				}
			}
		}

		void OverwritePositions()
        {
			overwriteData = SREvents.otherPlayerPos.getVec3();
        }
	}
}
