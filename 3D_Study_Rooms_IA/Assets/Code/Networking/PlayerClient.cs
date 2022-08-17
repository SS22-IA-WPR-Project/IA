using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firesplash.UnityAssets.SocketIO;

#if HAS_JSON_NET
using Newtonsoft.Json;
#endif

namespace Studyrooms {

    struct Vec3
    {
        public string _id;
        public float x;
        public float y;
        public float z;
    }

    struct combinedPlayer
    {
        public Vec3 position;
        public Avatar avatar;
        public GameObject go;
    }

    public class PlayerClient : MonoBehaviour
	{

        private Vec3 tmp;
        private Avatar tmpAvatar;
        private combinedPlayer cPlayer;
        private Vector3 oldPos;
        private Vector3 VecLength;
        private GameObject gaOb;
        public SocketIOCommunicator socCom;
        private List<GameObject> goList;
        // Start is called before the first frame update
        void Start()
        {
            

            oldPos = transform.position;

            gaOb = (GameObject)Resources.Load("Assets/own_prefabs/otherPlayers.prefab", typeof(GameObject));

            tmp = new Vec3
            {
                _id = PlayerPrefs.GetString("playerID"),
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z
            };

            tmpAvatar = new Avatar
            {
                _id = PlayerPrefs.GetString("playerID"),
                skin = PlayerPrefs.GetInt("skin"),
                bodybuild = PlayerPrefs.GetInt("bodyValue"),
                backpack = PlayerPrefs.GetInt("backpack"),
                helmet = PlayerPrefs.GetInt("helmet"),
                glasses = PlayerPrefs.GetInt("glasses")
            };


            socCom.Instance.On("connection", (string data) =>
            {
                Debug.Log("Connection made!");

                socCom.Instance.Emit("user:coordinate", JsonUtility.ToJson(tmp), false);

                socCom.Instance.Emit("user:sendAvatar", JsonUtility.ToJson(tmpAvatar), false);

            });

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
                Debug.Log("Geht in die IF rein");
                oldPos = transform.position;
                sendPosition();
            }

            if (false)
            {
                GameObject newGo = Instantiate(gaOb, Vector3.zero, Quaternion.identity);
                newGo.name = getAvatar()._id;
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
            tmp.x = (int)(transform.position.x * 1000f);
            tmp.y = (int)(transform.position.y * 1000f);
            tmp.z = (int)(transform.position.z * 1000f);
            Debug.Log("sendPosition du huan");
            socCom.Instance.Emit("user:coordinate", JsonUtility.ToJson(tmp), false);
        }

        private Vec3 getPositions()
        {
           Vec3 returnedPositions = new Vec3
            {
                _id = "",
                x = 0f,
                y = 0f,
                z = 0f
            };

            socCom.Instance.On("user:coordinate", (string data) =>
            {
                Debug.Log("Listening on user:coordinate!");
                returnedPositions = JsonUtility.FromJson<Vec3>(data);
                Debug.Log(data);
            });

            return returnedPositions;
        }

        private Avatar getAvatar()
        {
           Avatar returnedAvatar = new Avatar
            {
                _id = "",
                skin = 0,
                bodybuild = 0,
                backpack = 0,
                helmet = 0,
                glasses = 0
            };

            socCom.Instance.On("user:receiveAvatar", (string data) =>
            {
                returnedAvatar = JsonUtility.FromJson<Avatar>(data);
            });

            PlayerPrefs.SetInt("skin" + returnedAvatar._id, returnedAvatar.skin);
            PlayerPrefs.SetInt("bodybuild" + returnedAvatar._id, returnedAvatar.bodybuild);
            PlayerPrefs.SetInt("backpack" + returnedAvatar._id, returnedAvatar.backpack);
            PlayerPrefs.SetInt("helmet" + returnedAvatar._id, returnedAvatar.helmet);
            PlayerPrefs.SetInt("glasses" + returnedAvatar._id, returnedAvatar.glasses);

            SREvents.getOtherAvatars.Invoke();

            return returnedAvatar;
        }
	}
}