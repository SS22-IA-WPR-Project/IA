using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


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

        bool mode;

        string namethis;
        string emailthis;
        string passwordthis;

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

        private void Awake()
        {

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
        }


        public void LogIn()
        {
            //benutzerName.gameObject.SetActive(true);
            passwort.gameObject.SetActive(true);
            email.gameObject.SetActive(true);
            logInDone.gameObject.SetActive(true);

            login.gameObject.SetActive(false);
            signup.gameObject.SetActive(false);

            mode = false;
        }

        public void SignUp()
        {
            benutzerName.gameObject.SetActive(true);
            email.gameObject.SetActive(true);
            passwort.gameObject.SetActive(true);
            signUpDone.gameObject.SetActive(true);

            login.gameObject.SetActive(false);
            signup.gameObject.SetActive(false);

            mode = true;

        }

        public void setName(string namenew)
        {
            if (mode)
            {
                namethis = namenew;
                PlayerPrefs.SetString("userName" + namethis, namenew);
            }
            else
            {
                namethis = namenew;
            }

        }
        public void setEmail(string emailnew)
        {
            if (mode)
            {
                emailthis = emailnew;

            }
            else
            {
                emailthis = emailnew;
            }

        }
        public void setPasswort(string passwortnew)
        {
            if (mode)
            {
                passwordthis = passwortnew;

            }
            else
            {
                passwordthis = passwortnew;
            }

        }

        public void doneLogIn()
        {
            StartCoroutine(SendLogInData());
        }

        private IEnumerator SendLogInData()
        {

            PlayerPrefs.SetString("eMail" + namethis, emailthis);
            PlayerPrefs.SetString("password" + namethis, passwordthis);

            var user = new loginuser
            {
                email = email.text,
                password = passwort.text
            };

            if ((PlayerPrefs.GetString("userName" + namethis) != ""))
                Debug.Log("You Logged in with the Username: " + namethis);
            else
                Debug.Log("User not found");

            var request = LoginClient.Post("auth/login", JsonUtility.ToJson(user));

            yield return request.SendWebRequest();


            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
                
            }
            
            string testWorngAcc = "{\"messages\":[\"Invalid Username/Password\"]}";
            string testNoAcc = "{\"messages\":[\"Not found user\"]}";

            if (Encoding.Default.GetString(request.downloadHandler.data) == testNoAcc)
            {
                callbackMessage.text = "No Account with this E-Mail/Password exists";
                callbackMessage.color = Color.red;
                callbackMessage.gameObject.SetActive(true);
                benutzerName.text = "";
                email.text = "";
                passwort.text = "";

            }
            else if (Encoding.Default.GetString(request.downloadHandler.data) == testWorngAcc)
            {
                callbackMessage.text = "Worng E-Mail/Password for this Acc.";
                callbackMessage.color = Color.red;
                callbackMessage.gameObject.SetActive(true);
                benutzerName.text = "";
                email.text = "";
                passwort.text = "";
            }

            else
            {
                benutzerName.gameObject.SetActive(false);
                email.gameObject.SetActive(false);
                passwort.gameObject.SetActive(false);
                signUpDone.gameObject.SetActive(false);
                Debug.Log("testlogin");
                SREvents.sceneLoadSignUpToCharUi.Invoke();

            }

        }



        public void doneSignUp()
        {
            StartCoroutine(SendSignupData());
        }

        private IEnumerator SendSignupData()
        {

            PlayerPrefs.SetString("eMail" + namethis, emailthis);
            PlayerPrefs.SetString("password" + namethis, passwordthis);

            var user = new User
            {
                username = benutzerName.text,
                email = email.text,
                password = passwort.text
            };

            Debug.Log("You Signed up with the Username: " + user.username + "; and the Email: " + user.email);

            var request = LoginClient.Post("auth/signup", JsonUtility.ToJson(user));

            yield return request.SendWebRequest();

            Debug.Log("callback-data: " + Encoding.Default.GetString(request.downloadHandler.data));

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
                
            }

            string test = "{\"succes\":true}";
            
            if (Encoding.Default.GetString(request.downloadHandler.data) == test){
                benutzerName.gameObject.SetActive(false);
                email.gameObject.SetActive(false);
                passwort.gameObject.SetActive(false);
                signUpDone.gameObject.SetActive(false); 
                Debug.Log("testsignUp");
                SREvents.sceneLoadSignUpToCharUi.Invoke();
            }
            else
            {
                callbackMessage.text = "Account with this E-Mail allready exists.";
                callbackMessage.color = Color.red;
                callbackMessage.gameObject.SetActive(true);
                benutzerName.text = "";
                email.text = "";
                passwort.text = "";
            }
           


        }
     }
}