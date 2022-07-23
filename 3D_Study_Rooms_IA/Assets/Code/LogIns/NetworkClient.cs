using Firesplash.UnityAssets.SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


#if HAS_JSON_NET
using Newtonsoft.Json;
#endif

namespace Studyrooms
{
    public class NetworkClient : MonoBehaviour
    {
        public SocketIOCommunicator socCom;
        // Start is called before the first frame update
        void Start()
        {

            socCom.Instance.On("connection", (string data) =>
            {
                Debug.Log("Connection made!");

                socCom.Instance.Emit("Hello there");
            });

            socCom.Instance.On("disconnect", (string payload) =>
            {

            });


            socCom.Instance.Connect("http://localhost:3000", false);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}