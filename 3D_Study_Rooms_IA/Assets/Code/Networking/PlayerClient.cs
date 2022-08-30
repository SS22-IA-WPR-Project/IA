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
        private Anim currentAnim;
        private Anim oldAnim;
        private Anim returnedAnim;

        private List<combinedPlayer> goList;

        private Vector3 oldPos;
        private float oldRot;
        private Vector3 VecLength;

        public GameObject gaOb;
        public SocketIOCommunicator socCom;

        // Start is called before the first frame update
        void Start()
        {
            //start configuration for structs
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

            SREvents.reloadAvatar.AddListener(reloadAvatar);

            //create connections to the backend via their respective waypoints.

            socCom.Instance.On("connection", (string data) =>
            {
                Debug.Log("Connection made!");

                socCom.Instance.Emit("user:sendCoordinate", JsonUtility.ToJson(userPosition), false);
                socCom.Instance.Emit("user:sendAvatar", JsonUtility.ToJson(tmpAvatar), false);

            });

            socCom.Instance.On("disconnect", (string payload) =>
            {
                Debug.Log("disconnected");
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
                string _id = JsonUtility.FromJson<string>(data);
                combinedPlayer left = new combinedPlayer { };
                for (int i = 0; i <= goList.Count; i++)
                {
                    if (goList[i]._id == _id)
                    {
                        left = goList[i];
                        goList.RemoveAt(i);
                        Destroy(left.go);
                    }
                }
                Debug.Log("has left");
            });

            socCom.Instance.Connect("http://3dstudyrooms.social", false);
        }

        private void Update()
        {
            VecLength = (transform.position - oldPos);
            float rotDif = Mathf.Abs(transform.rotation.y - oldRot);
            if (VecLength.magnitude > 0.1f || transform.rotation.y != oldRot)
            {
                oldPos = transform.position;
                oldRot = transform.rotation.y;
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
           // if(goList.Count > 0)
           // {
                
           // }
            for (int i = 0; i < goList.Count; i++)
            {
                Vector3 tester = new Vector3(goList[i].position.x, goList[i].position.y, goList[i].position.z);

                if (tester != goList[i].go.transform.position)
                {
                    SREvents.otherPlayerPos.Invoke(returnedPositions);
                }
            }
        }

        private void sendPosition()
        {
            userPosition.x = (int)(transform.position.x * 1000f);
            userPosition.y = (int)(transform.position.y * 1000f);
            userPosition.z = (int)(transform.position.z * 1000f);
            userPosition.rot = (int)(transform.rotation.y * 1799f);
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
            returnedPositions.rot = (returnedPositions.rot / 10f);

            if(goList.Count == 0)
            {
                goList.Add(tmp2);
            }
            else
            {
                bool newUser = false;
                for (int i = 0; i <= goList.Count; i++)
                {
                    if (goList[i]._id == returnedPositions._id)
                    {
                        tmp2 = goList[i];
                        tmp2.position = returnedPositions;
                        goList[i] = tmp2;
                        newUser = true;
                        Debug.Log("new User value" + newUser);
                        break;
                    }
                }
                if (!newUser)
                {
                    Debug.Log("geht in if(newUser)" + newUser);
                    goList.Add(tmp2);
                }
            }
        }

        private void getAnim()
        {
            PlayerPrefs.SetInt("up" + returnedAnim._id, returnedAnim.forwardReceive ? 1 : 0);
            PlayerPrefs.SetInt("down" + returnedAnim._id, returnedAnim.backwardReceive ? 1 : 0);
            PlayerPrefs.SetInt("right" + returnedAnim._id, returnedAnim.rightReceive ? 1 : 0);
            PlayerPrefs.SetInt("left" + returnedAnim._id, returnedAnim.leftReceive ? 1 : 0);

            SREvents.otherPlayerAnim.Invoke(returnedAnim._id);
        }

        private void getAvatar()
        {

            Vector3 overwriteOtherPosition = new Vector3(returnedPositions.x, returnedPositions.y, returnedPositions.z);
            Quaternion overwriteRot = Quaternion.Euler(0f, returnedPositions.rot, 0f);

            GameObject newGo = gaOb;

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
            SREvents.getOtherAvatars.Invoke(returnedAvatar._id);
        }

        private void reloadAvatar()
        {
            Avatar tmpAvatar = new Avatar
            {
                _id = PlayerPrefs.GetString("playerID"),
                skin = PlayerPrefs.GetInt("skin"),
                bodybuild = PlayerPrefs.GetInt("bodyValue"),
                backpack = PlayerPrefs.GetInt("backpack"),
                helmet = PlayerPrefs.GetInt("helmet"),
                glasses = PlayerPrefs.GetInt("glasses")
            };

            socCom.Instance.Emit("user:sendAvatar", JsonUtility.ToJson(tmpAvatar), false);
        }
	}
}
