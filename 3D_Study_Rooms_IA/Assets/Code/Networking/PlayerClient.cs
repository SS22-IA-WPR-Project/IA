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
        public string _id;
        public Vec3 position;
        public Avatar avatar;
        public GameObject go;
    }

    public class PlayerClient : MonoBehaviour
	{

        private Vec3 userPosition;
        private Vec3 returnedPositions;
        private Avatar returnedAvatar;
        private Vector3 oldPos;
        private Vector3 VecLength;
        private GameObject gaOb;
        public SocketIOCommunicator socCom;
        private List<combinedPlayer> goList;
        // Start is called before the first frame update
        void Start()
        {
            

            oldPos = transform.position;

            gaOb = (GameObject)Resources.Load("Assets/own_prefabs/otherPlayers.prefab", typeof(GameObject));

            userPosition = new Vec3
            {
                _id = PlayerPrefs.GetString("playerID"),
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z
            };

            Avatar tmpAvatar = new Avatar
            {
                _id = PlayerPrefs.GetString("playerID"),
                skin = PlayerPrefs.GetInt("skin"),
                bodybuild = PlayerPrefs.GetInt("bodyValue"),
                backpack = PlayerPrefs.GetInt("backpack"),
                helmet = PlayerPrefs.GetInt("helmet"),
                glasses = PlayerPrefs.GetInt("glasses")
            };

            returnedAvatar = new Avatar
            {
                _id = "",
                skin = 0,
                bodybuild = 0,
                backpack = 0,
                helmet = 0,
                glasses = 0
            };

            returnedPositions = new Vec3
            {
                _id = "",
                x = 0f,
                y = 0f,
                z = 0f
            };


            socCom.Instance.On("connection", (string data) =>
            {
                Debug.Log("Connection made!");

                socCom.Instance.Emit("user:sendCoordinate", JsonUtility.ToJson(userPosition), false);

                socCom.Instance.Emit("user:sendAvatar", JsonUtility.ToJson(tmpAvatar), false);

            });

            socCom.Instance.On("disconnect", (string payload) =>
            {
                Destroy(this.gameObject);
            });


            socCom.Instance.Connect("http://localhost:8080", false);

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

            socCom.Instance.On("user:receiveCoordinate", (string data) =>
            {
                Debug.Log("Listening on user:receiveCoordinate!");
                returnedPositions = JsonUtility.FromJson<Vec3>(data);
               // Debug.Log(data);
            });

            if(returnedPositions._id != "")
            {
                getPositions();
            }

            socCom.Instance.On("user:receiveAvatar", (string data) =>
            {
                returnedAvatar = JsonUtility.FromJson<Avatar>(data);
            });


            if (returnedAvatar._id != "")
            {
                GameObject newGo = Instantiate(gaOb, Vector3.zero, Quaternion.identity);
                getAvatar();
                newGo.name = returnedAvatar._id;
            }

        }

        private void sendPosition()
        {
            userPosition.x = (int)(transform.position.x * 1000f);
            userPosition.y = (int)(transform.position.y * 1000f);
            userPosition.z = (int)(transform.position.z * 1000f);
            socCom.Instance.Emit("user:sendCoordinate", JsonUtility.ToJson(userPosition), false);
        }

        private void getPositions()
        {
            combinedPlayer tmp2 = new combinedPlayer
            {
                _id = "",
                position = returnedPositions,
                avatar = returnedAvatar,
                go = new GameObject()
            };

            Vector3 overwritePosition = new Vector3 ( 0f, 0f, 0f );

            for(int i = 0; i<= goList.Count; i++)
            {
                if(goList[i]._id == returnedPositions._id)
                {

                    tmp2 = goList[i];
                    goList.RemoveAt(i);
                    tmp2.position = returnedPositions;
                    overwritePosition.x = returnedPositions.x;
                    overwritePosition.y = returnedPositions.y;
                    overwritePosition.z = returnedPositions.z;
                    tmp2.go.transform.position = overwritePosition;
                    goList.Add(tmp2);
                    break;
                }
            }
        }

        private void getAvatar()
        {
            combinedPlayer tmpPlayer = new combinedPlayer
            {
                _id = "",
                position = returnedPositions,
                avatar = returnedAvatar,
                go = new GameObject()
            };

            PlayerPrefs.SetInt("skin" + returnedAvatar._id, returnedAvatar.skin);
            PlayerPrefs.SetInt("bodybuild" + returnedAvatar._id, returnedAvatar.bodybuild);
            PlayerPrefs.SetInt("backpack" + returnedAvatar._id, returnedAvatar.backpack);
            PlayerPrefs.SetInt("helmet" + returnedAvatar._id, returnedAvatar.helmet);
            PlayerPrefs.SetInt("glasses" + returnedAvatar._id, returnedAvatar.glasses);

            for(int i = 0; i <= goList.Count; i++)
            {
                if(goList[i]._id == returnedAvatar._id)
                {
                    tmpPlayer = goList[i];
                    goList.RemoveAt(i);
                    tmpPlayer.avatar = returnedAvatar;
                    goList.Add(tmpPlayer);
                    break;
                }
            }

            SREvents.getOtherAvatars.Invoke();

        }
	}
}