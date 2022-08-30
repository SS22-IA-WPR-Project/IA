using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

namespace Studyrooms
{
    public class LogInHandler : MonoBehaviour
    {
        public Button login;
        public Button signup;
        public Button logInDone;
        public Button signUpDone;

        public InputField benutzerName;
        public InputField email;
        public InputField passwort;

        public Text callbackMessage;

        EventSystem system;
        public struct User
        {
            public string username;
            public string email;
            public string password;
        }

        public struct loginuser
        {
            public string email;
            public string password;
        }

        // Start is called before the first frame update
        void Start()
        {
            benutzerName.gameObject.SetActive(false);
            email.gameObject.SetActive(false);
            passwort.gameObject.SetActive(false);
            logInDone.gameObject.SetActive(false);
            signUpDone.gameObject.SetActive(false);
            callbackMessage.gameObject.SetActive(false);
            system = EventSystem.current;
        }

        public void LogIn()
        {
            passwort.gameObject.SetActive(true);
            email.gameObject.SetActive(true);
            logInDone.gameObject.SetActive(true);

            login.gameObject.SetActive(false);
            signup.gameObject.SetActive(false);
        }

        public void SignUp()
        {
            benutzerName.gameObject.SetActive(true);
            email.gameObject.SetActive(true);
            passwort.gameObject.SetActive(true);
            signUpDone.gameObject.SetActive(true);

            login.gameObject.SetActive(false);
            signup.gameObject.SetActive(false);
        }

        public void doneLogIn()
        {
            StartCoroutine(SendLogInData());
        }

        private IEnumerator SendLogInData()
        {
            var user = new loginuser
            {
                email = email.text,
                password = passwort.text
            };

            var request = LoginClient.Post("auth/login", JsonUtility.ToJson(user));

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
                callbackMessage.text = "Server Connection error";
            }          

            string testWorngAcc = "{\"messages\":[\"Invalid Username/Password\"]}";
            string testNoAcc = "{\"messages\":[\"Not found user\"]}";
            string callback = Encoding.Default.GetString(request.downloadHandler.data);

            if (callback == testNoAcc)
            {
                callbackMessage.text = "No Account with this E-Mail/Password exists";
                callbackMessage.color = Color.red;
                callbackMessage.gameObject.SetActive(true);
                benutzerName.text = "";
                email.text = "";
                passwort.text = "";
            }
            else if (callback == testWorngAcc)
            {
                callbackMessage.text = "Wrong E-Mail/Password for this Acc.";
                callbackMessage.color = Color.red;
                callbackMessage.gameObject.SetActive(true);
                benutzerName.text = "";
                email.text = "";
                passwort.text = "";
            }
            else
            {
                string[] tmp = callback.Split(':');
                string playerID = tmp[tmp.Length - 1].Substring(1, tmp[tmp.Length - 1].Length - 3);
                PlayerPrefs.SetString("playerID", playerID);
                benutzerName.gameObject.SetActive(false);
                email.gameObject.SetActive(false);
                passwort.gameObject.SetActive(false);
                signUpDone.gameObject.SetActive(false);
                Debug.Log("testlogin " + playerID);
                SREvents.sceneLoadLogInToClass.Invoke();
            }
        }

        public void doneSignUp()
        {
            StartCoroutine(SendSignupData());
        }

        private IEnumerator SendSignupData()
        {
            var user = new User
            {
                username = benutzerName.text,
                email = email.text,
                password = passwort.text
            };

            var request = LoginClient.Post("auth/signup", JsonUtility.ToJson(user));

            yield return request.SendWebRequest();

            Debug.Log("callback-data: " + Encoding.Default.GetString(request.downloadHandler.data));

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
                callbackMessage.text = "Server Connection error";
            }

            string test = "\"succes\":true";
            string callback = Encoding.Default.GetString(request.downloadHandler.data);

            if (callback.Contains(test))
            {
                string playerID = callback.Substring(22, callback.Length - 24);
                PlayerPrefs.SetString("playerID", playerID);
                benutzerName.gameObject.SetActive(false);
                email.gameObject.SetActive(false);
                passwort.gameObject.SetActive(false);
                signUpDone.gameObject.SetActive(false);
                Debug.Log("testsignUp " + playerID);
                SREvents.sceneLoadSignUpToCharUi.Invoke();
            }
            else
            {
                callbackMessage.text = "";

                if (callback.Contains("\"msg\":\"Min. 6 Character-Length\""))
                {
                    callbackMessage.text += "Please choose a username with at least 6 characters.\n";
                }
                if (callback.Contains("\"msg\":\"Invalid value\",\"param\":\"password\""))
                {
                    callbackMessage.text += "Please choose a password with at 8-32 characters.\n";
                }
                if (callback.Contains(" \"msg\": \"Should be a valid adress[th - koeln.de or fh - koeln.de]\""))
                {
                    callbackMessage.text += "Please choose a TH-Email adress.";
                }
                if(callback.Contains("\"messages\":[\"user already exits\"]"))
                {
                    callbackMessage.text = "Account with this E-Mail allready exists.";
                }

                callbackMessage.color = Color.red;
                callbackMessage.gameObject.SetActive(true);
                benutzerName.text = "";
                email.text = "";
                passwort.text = "";
            }
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
                
                if (next != null)
                {
                    Debug.Log(next.name);
                    next.Select();
                }
            }
        }
    }
}