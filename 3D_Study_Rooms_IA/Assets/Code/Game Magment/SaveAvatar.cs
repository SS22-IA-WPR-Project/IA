using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace Studyrooms {
    public class SaveAvatar : MonoBehaviour
{
        public Button goToClass;
        struct Avatar
        {
            public string _id;
            public int skin;
            public int bodybuild;
            public int backpack;
            public int helmet;
            public int glasses;
        }
        // Start is called before the first frame update
        void Start()
        {
            goToClass.gameObject.SetActive(false);
             
        }
        public void doneAvatar()
        {
            StartCoroutine(sendAvatarData());
        }

        IEnumerator sendAvatarData()
        {
            var avatar = new Avatar
            {
                _id = PlayerPrefs.GetString("playerID"),
                skin = PlayerPrefs.GetInt("skin"),
                bodybuild = PlayerPrefs.GetInt("bodyValue"),
                backpack = PlayerPrefs.GetInt("backpack"),
                helmet = PlayerPrefs.GetInt("helmet"),
                glasses = PlayerPrefs.GetInt("glasses")

            };

            var request = LoginClient.Post("user/create", JsonUtility.ToJson(avatar));

            yield return request.SendWebRequest();

            Debug.Log("callback-data: " + Encoding.Default.GetString(request.downloadHandler.data));

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);

            }
            else
            {
                goToClass.gameObject.SetActive(true);
            }
        }
    }
}
