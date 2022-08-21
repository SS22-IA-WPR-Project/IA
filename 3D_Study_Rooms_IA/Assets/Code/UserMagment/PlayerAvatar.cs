using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Studyrooms
{
    public class PlayerAvatar : MonoBehaviour
    {
        public GameObject backpack;
        public GameObject helmet;
        public GameObject glasses1;
        public GameObject glasses2;
        public Mesh[] bodybuilds = new Mesh[2];
        public Material[] skins = new Material[10];
        public string nameId;
        public string thisID;

        new SkinnedMeshRenderer renderer;

        /*struct Avatar
        {
            public string _id;
            public int skin;
            public int bodybuild;
            public int backpack;
            public int helmet;
            public int glasses;
        }*/

        struct playerIDstruc
        {
            public string _id;
        }


        Avatar avatar;

        private void Awake()
        {
            
            SREvents.getUserAvatar.AddListener(userAvatar);
            SREvents.loadAvatar.AddListener(setAvatar);
            SREvents.getOtherAvatars.AddListener(getOtherAvatars);
        }

        // Start is called before the first frame update
        void Start()
        {

            thisID = GetComponentInParent<GameObject>().GetComponentInParent<GameObject>().name;
        }
        private void userAvatar()
        {
            StartCoroutine(getAvatarData());
        }

        IEnumerator getAvatarData()
        {

            Debug.Log(PlayerPrefs.GetString("playerID"));

            playerIDstruc id = new playerIDstruc
            {
                _id = PlayerPrefs.GetString("playerID")
            };

            var request = LoginClient.Post("user/avatar", JsonUtility.ToJson(id));

            yield return request.SendWebRequest();


            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);

            }

            avatar = JsonUtility.FromJson<Avatar>(request.downloadHandler.text);


            SREvents.loadAvatar.Invoke();
        }

        public void getOtherAvatars()
        {
            nameId = SREvents.getOtherAvatars.GetId();
            if(nameId == thisID)
            {
                Debug.Log(nameId);
                avatar = new Avatar
                {
                    skin = PlayerPrefs.GetInt("skin" + nameId),
                    bodybuild = PlayerPrefs.GetInt("bodybuild" + nameId),
                    backpack = PlayerPrefs.GetInt("backpack" + nameId),
                    helmet = PlayerPrefs.GetInt("helmet" + nameId),
                    glasses = PlayerPrefs.GetInt("glasses" + nameId)
                };
                Debug.Log("avatar skin:" + avatar.skin);
                Debug.Log("avatar bodybuild:" + avatar.bodybuild);
                Debug.Log("avatar backpack:" + avatar.backpack);
                Debug.Log("avatar helmet:" + avatar.helmet);
                Debug.Log("avatar glasses:" + avatar.glasses);
                SREvents.loadAvatar.Invoke();
            }
            
        }

        public void setAvatar()
        {
            renderer = gameObject.GetComponent<SkinnedMeshRenderer>();

            //skin
            renderer.material = skins[avatar.skin];
            Debug.Log("avatar skin:" + avatar.skin);
            //bodybuild
            Bodybuild(avatar.bodybuild);
            Debug.Log("setAvatar bodybuild:" + avatar.bodybuild);
            //backpack
            backpackActive(avatar.backpack == 1 ? true : false);
            Debug.Log("setAvatar backpack:" + avatar.backpack);
            //helmet
            helmetActive(avatar.helmet == 1 ? true : false);
            Debug.Log("setAvatar helmet:" + avatar.helmet);
            //glasses
            glasses(avatar.glasses);
            Debug.Log("setAvatar glasses:" + avatar.glasses);
            SREvents.loadAvatar.RemoveListener(setAvatar);
        }

        public void backpackActive(bool state)
        {
            backpack.SetActive(state);
        }

        public void helmetActive(bool state)
        {
            helmet.SetActive(state);
        }

        public void glasses(int value)
        {
            switch (value)
            {
                case 0:
                    glasses1.SetActive(false);
                    glasses2.SetActive(false);
                    break;
                case 1:
                    glasses1.SetActive(true);
                    glasses2.SetActive(false);
                    break;
                case 2:
                    glasses1.SetActive(false);
                    glasses2.SetActive(true);
                    break;

            }
        }
        public void Bodybuild(float value)
        {
            if (value == 0)
            {
                renderer.sharedMesh = bodybuilds[(int)value];
            }
            else
            {
                renderer.sharedMesh = bodybuilds[(int)value];
            }

        }


    }
}