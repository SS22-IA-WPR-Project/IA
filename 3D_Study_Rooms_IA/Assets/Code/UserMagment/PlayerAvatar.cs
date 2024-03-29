using System.Collections;
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

        string nameId;
        string thisID;

        new SkinnedMeshRenderer renderer;

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
            thisID = transform.root.name;
        }

        private void userAvatar()
        {
            StartCoroutine(getAvatarData());
        }

        IEnumerator getAvatarData()
        {
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
            renderer = gameObject.GetComponent<SkinnedMeshRenderer>();
            nameId = SREvents.getOtherAvatars.getId();
            thisID = transform.root.name;
            if(nameId == thisID)
            {
                avatar = new Avatar
                {
                    skin = PlayerPrefs.GetInt("skin" + nameId),
                    bodybuild = PlayerPrefs.GetInt("bodybuild" + nameId),
                    backpack = PlayerPrefs.GetInt("backpack" + nameId),
                    helmet = PlayerPrefs.GetInt("helmet" + nameId),
                    glasses = PlayerPrefs.GetInt("glasses" + nameId)
                };
                renderer.material = skins[avatar.skin];
                Bodybuild(avatar.bodybuild);
                backpackActive(avatar.backpack == 1 ? true : false);
                helmetActive(avatar.helmet == 1 ? true : false);
                glasses(avatar.glasses);


            }
            
        }

        public void setAvatar()
        {
            renderer = gameObject.GetComponent<SkinnedMeshRenderer>();

            //skin
            renderer.material = skins[avatar.skin];
            //bodybuild
            Bodybuild(avatar.bodybuild);
            //backpack
            backpackActive(avatar.backpack == 1 ? true : false);
            //helmet
            helmetActive(avatar.helmet == 1 ? true : false);
            //glasses
            glasses(avatar.glasses);
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