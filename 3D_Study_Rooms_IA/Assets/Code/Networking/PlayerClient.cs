using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firesplash.UnityAssets.SocketIO;

#if HAS_JSON_NET
using Newtonsoft.Json;
#endif

namespace Studyrooms {
	public class PlayerClient : MonoBehaviour
	{
        struct Vec3
        {
            public string _id;
            public float x;
            public float y;
            public float z;
        }

        private Vec3 tmp;
        private Vector3 oldPos;
        private Vector3 VecLength;
        public SocketIOCommunicator socCom;
        // Start is called before the first frame update
        void Start()
        {
            oldPos = transform.position;

            tmp = new Vec3
            {
                _id = PlayerPrefs.GetString("playerID"),
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z
            };

            socCom.Instance.On("connection", (string data) =>
            {
                Debug.Log("Connection made!");

                socCom.Instance.Emit("user:coordinate", JsonUtility.ToJson(tmp), false);
            });

            sendPosition();

            socCom.Instance.On("disconnect", (string payload) =>
            {

            });


            socCom.Instance.Connect("http://localhost:8080", false);

           // StartCoroutine(UpdatePosition());

        }
        private void Update()
        {
            VecLength = (transform.position - oldPos);
            if (VecLength.magnitude > 0.1f)
            {
                tmp.x = transform.position.x;
                tmp.y = transform.position.y;
                tmp.z = transform.position.z;
                Debug.Log("Geht in die IF rein");
                oldPos = transform.position;
                sendPosition();
            }

        }

      /*  IEnumerator UpdatePosition()
        {
            Debug.Log("geht in UpdatePosition rein");
            yield return new WaitUntil(() => socCom.Instance.IsConnected());

            if(oldPos != transform.position)
            {
                Debug.Log("Geht in die IF rein");
                oldPos = transform.position;
                sendPosition();
            }

        }*/

        private void sendPosition()
        {
            Debug.Log("sendPosition du huan");
            socCom.Instance.Emit("user:coordinate", JsonUtility.ToJson(tmp), false);

        }

    
        // Start is called before the first frame update
        Vector3 GetPosition()
        {
			return transform.position;
        }
	}
}