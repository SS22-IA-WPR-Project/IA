using Firesplash.UnityAssets.SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#if HAS_JSON_NET
using Newtonsoft.Json;
#endif

namespace Studyrooms
{
    public class NetworkClient : MonoBehaviour
    {
        struct Vec3
        {
            public string _id;
            public float x;
            public float y;
            public float z;
        }

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

           /*socCom.Instance.On("user:coordinate", (string data) =>
            {
                Debug.Log("get hier rein");
                socCom.Instance.Emit("Hello there");
               // socCom.Instance.Emit("user:coordinate", JsonUtility.ToJson(), true);
            });*/
           
            socCom.Instance.Connect("http://localhost:8080", false);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}