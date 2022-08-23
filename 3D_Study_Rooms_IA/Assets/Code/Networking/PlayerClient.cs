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
        public float rot;
    }

    struct combinedPlayer
    {
        public string _id;
        public Vec3 position;
        public Avatar avatar;
        public GameObject go;
    }

    struct Anim
    {
        public string _id;
        public bool forwardReceive;
        public bool backwardReceive;
        public bool rightReceive;
        public bool leftReceive;
    }

    public class PlayerClient : MonoBehaviour
	{

        private Vec3 userPosition;
        private Vec3 returnedPositions;
        private Avatar returnedAvatar;
        private Vector3 oldPos;
        private float oldRot;
        private Vector3 VecLength;
        public GameObject gaOb;
        //private Animator animator;
        private Anim currentAnim;
        private Anim oldAnim;
        private Anim returnedAnim;
        public SocketIOCommunicator socCom;
        private List<combinedPlayer> goList;
        // Start is called before the first frame update
        void Start()
        {
            currentAnim = new Anim
            {
                _id = PlayerPrefs.GetString("playerID"),
                forwardReceive = false,
                backwardReceive = false,
                rightReceive = false,
                leftReceive = false
            };

            oldAnim = new Anim
            {
                _id = PlayerPrefs.GetString("playerID"),
                forwardReceive = false,
                backwardReceive = false,
                rightReceive = false,
                leftReceive = false
            };

            returnedAnim = new Anim
            {
                _id = "",
                forwardReceive = false,
                backwardReceive = false,
                rightReceive = false,
                leftReceive = false
            };

            goList = new List<combinedPlayer>();

            oldPos = transform.position;
            oldRot = 0;

            //gaOb = (GameObject)Resources.Load("Assets/own_prefabs/otherPlayers.prefab", typeof(GameObject));

            userPosition = new Vec3
            {
                _id = PlayerPrefs.GetString("playerID"),
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z,
                rot = transform.rotation.y
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
                z = 0f,
                rot = 0f
            };


            socCom.Instance.On("connection", (string data) =>
            {
                Debug.Log("Connection made!");

                socCom.Instance.Emit("user:sendCoordinate", JsonUtility.ToJson(userPosition), false);

                socCom.Instance.Emit("user:sendAvatar", JsonUtility.ToJson(tmpAvatar), false);

            });

            socCom.Instance.On("disconnect", (string payload) =>
            {
                killed();
            });

            socCom.Instance.On("user:receiveCoordinate", (string data) =>
            {
                returnedPositions = JsonUtility.FromJson<Vec3>(data);

                if (returnedPositions._id != "")
                {
                    getPositions();
                }
            });

            socCom.Instance.On("user:receiveAvatar", (string data) =>
            {
                returnedAvatar = JsonUtility.FromJson<Avatar>(data);

                if (returnedAvatar._id != "")
                {
                    getAvatar();
                }
            });

            socCom.Instance.On("user:receiveAnim", (string data) =>
            {
                returnedAnim = JsonUtility.FromJson<Anim>(data);

                if(returnedAnim._id != "")
                {
                    getAnim();
                }
            });

            socCom.Instance.On("user has left", (string data) =>
            {
                Debug.Log("has left");
            });

            //socCom.Instance.Connect("http://35.228.121.222", false);
            socCom.Instance.Connect("http://25.59.255.245:8080", false);

        }
        private void Update()
        {
            VecLength = (transform.position - oldPos);
            float rotDif = Mathf.Abs(transform.rotation.y - oldRot);
            Debug.Log("rotDif : " + rotDif);
            if (VecLength.magnitude > 0.1f || transform.rotation.y != oldRot)//rotDif > 0.01f)
            {
                oldPos = transform.position;
                oldRot = transform.rotation.y;
                Debug.Log("update: " + oldRot);
                sendPosition();
            }


            currentAnim.forwardReceive = (Input.GetKey("up") || Input.GetKey("w"));
            currentAnim.backwardReceive = (Input.GetKey("down") || Input.GetKey("s"));
            currentAnim.rightReceive = (Input.GetKey("right") || Input.GetKey("d"));
            currentAnim.leftReceive = (Input.GetKey("left") || Input.GetKey("a"));

            if (currentAnim.forwardReceive != oldAnim.forwardReceive ||
                currentAnim.backwardReceive != oldAnim.backwardReceive ||
                currentAnim.rightReceive != oldAnim.rightReceive ||
                currentAnim.leftReceive != oldAnim.leftReceive)
            {
                oldAnim = currentAnim;
                sendAnim();
            }

            for (int i = 0; i <= goList.Count; i++)
            {
                Vector3 tester = new Vector3(goList[i].position.x, goList[i].position.y, goList[i].position.z);

                if (tester != goList[i].go.transform.position)
                {
                   /* Debug.Log("new x tester Pos: " + tester.x);
                    goList[i].go.transform.position = tester;
                    Debug.Log("new x Pos: " + goList[i].go.transform.position.x);*/
                    SREvents.otherPlayerPos.Invoke(returnedPositions);

                }
            }
        }

        private void killed()
        {
            Destroy(this.gameObject);
        }

        private void sendPosition()
        {
            userPosition.x = (int)(transform.position.x * 1000f);
            userPosition.y = (int)(transform.position.y * 1000f);
            userPosition.z = (int)(transform.position.z * 1000f);
            userPosition.rot = (int)(transform.rotation.y * 100f);
            Debug.Log("sendPosition: " + userPosition.rot);
            socCom.Instance.Emit("user:sendCoordinate", JsonUtility.ToJson(userPosition), false);
        }

        private void sendAnim()
        {

            socCom.Instance.Emit("user:sendAnim", JsonUtility.ToJson(currentAnim), false);
        }

        private void getPositions()
        {
            combinedPlayer tmp2 = new combinedPlayer
            {
                _id = returnedPositions._id,
                position = returnedPositions,
                avatar = returnedAvatar,
                go = gaOb
            };

            returnedPositions.x = (returnedPositions.x / 1000f);
            returnedPositions.y = (returnedPositions.y / 1000f);
            returnedPositions.z = (returnedPositions.z / 1000f);
            //returnedPositions.rot = (returnedPositions.rot / 1000f);

            //Vector3 overwritePosition = new Vector3 ( 0f, 0f, 0f );

            if(goList.Count == 0)
            {
                goList.Add(tmp2);
            }
            else
            {
                bool newUser = true;
                for (int i = 0; i <= goList.Count; i++)
                {
                    if (goList[i]._id == returnedPositions._id)
                    {

                        tmp2 = goList[i];
                        //goList.RemoveAt(i);
                        tmp2.position = returnedPositions;
                        /*overwritePosition.x = returnedPositions.x;
                        Debug.Log("zwischen Overwrite positions + x : " + overwritePosition.x);
                        overwritePosition.y = returnedPositions.y;
                        overwritePosition.z = returnedPositions.z;
                        tmp2.go.transform.position = overwritePosition;*/
                        goList.Add(tmp2);
                        newUser = false;
                        break;
                    }
                }
                if (newUser)
                {
                    goList.Add(tmp2);
                }
            }
        }

        private void getAnim()
        {
            PlayerPrefs.SetInt("up" + returnedAnim._id, returnedAnim.forwardReceive ? 1 : 0);
            PlayerPrefs.SetInt("down" + returnedAnim._id, returnedAnim.backwardReceive ? 1 : 0);
            PlayerPrefs.SetInt("right" + returnedAnim._id, returnedAnim.rightReceive ? 1 : 0);
            PlayerPrefs.SetInt("left" + returnedAnim._id, returnedAnim.rightReceive ? 1 : 0);

            SREvents.otherPlayerAnim.Invoke(returnedAnim._id);

        }

        private void getAvatar()
        {

            Vector3 overwriteOtherPosition = new Vector3(returnedPositions.x, returnedPositions.y, returnedPositions.z);
            //overwriteOtherPosition.x = returnedPositions.x;
            //overwriteOtherPosition.y = returnedPositions.y;
            //overwriteOtherPosition.z = returnedPositions.z;

            Quaternion overwriteRot = Quaternion.Euler(0f, returnedPositions.rot, 0f);

            GameObject newGo = gaOb;

            Debug.Log("vor dem struct");

            combinedPlayer tmpPlayer = new combinedPlayer
            {
                _id = returnedAvatar._id,
                position = returnedPositions,
                avatar = returnedAvatar,
                go = gaOb
            };

            PlayerPrefs.SetInt("skin" + returnedAvatar._id, returnedAvatar.skin);
            PlayerPrefs.SetInt("bodybuild" + returnedAvatar._id, returnedAvatar.bodybuild);
            PlayerPrefs.SetInt("backpack" + returnedAvatar._id, returnedAvatar.backpack);
            PlayerPrefs.SetInt("helmet" + returnedAvatar._id, returnedAvatar.helmet);
            PlayerPrefs.SetInt("glasses" + returnedAvatar._id, returnedAvatar.glasses);

            Debug.Log("vor der for" + goList.Count);

            if(goList.Count == 0)
            {
                goList.Add(tmpPlayer);
                newGo = Instantiate(tmpPlayer.go, overwriteOtherPosition, overwriteRot);
                newGo.name = returnedAvatar._id;
            }
            else
            {
                bool newUser = true;
                for(int i = 0; i <= goList.Count; i++)
                {
                    if(goList[i]._id == returnedAvatar._id)
                    {
                        tmpPlayer = goList[i];
                        goList.RemoveAt(i);
                        tmpPlayer.avatar = returnedAvatar;
                        goList.Add(tmpPlayer);
                        Debug.Log("vorm break");
                        if (GameObject.Find(returnedAvatar._id) == null)
                        {
                            newGo = Instantiate(tmpPlayer.go, overwriteOtherPosition, overwriteRot);
                            newGo.name = returnedAvatar._id;
                        }
                        newUser = false;
                        break;
                    }
                }
                if (newUser)
                {
                    newGo = Instantiate(tmpPlayer.go, overwriteOtherPosition, overwriteRot);
                    newGo.name = returnedAvatar._id;
                    goList.Add(tmpPlayer);
                }
            }

            Debug.Log("geht vors Event");
            SREvents.getOtherAvatars.Invoke(returnedAvatar._id);

        }
	}
}
