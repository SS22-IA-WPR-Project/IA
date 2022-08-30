using Firesplash.UnityAssets.SocketIO;
using UnityEngine;

#if HAS_JSON_NET
using Newtonsoft.Json;
#endif

namespace Studyrooms
{
    public class NetworkClient : MonoBehaviour
    {
        private Vec3 tmp;
        public SocketIOCommunicator socCom;

        // Start is called before the first frame update
        void Start()
        {
            tmp = new Vec3 
            { 
                _id = "lol",
                x = 12f,
                y = 5f,
                z = 0f 
            };

            socCom.Instance.On("connection", (string data) =>
            {
                Debug.Log("Connection made!");

                socCom.Instance.Emit("user:coordinate", JsonUtility.ToJson(tmp), false);
            });

            socCom.Instance.On("disconnect", (string payload) =>
            {

            });
           
            socCom.Instance.Connect("http://localhost:8080", false);
        }
    }
}