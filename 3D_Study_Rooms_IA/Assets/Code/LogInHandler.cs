using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInHandler : MonoBehaviour
{

    public Button login;
    public Button signup;
    public Button logInDone;
    public Button signUpDone;

    public InputField benutzerName;
    public InputField email;
    public InputField passwort;

    bool mode;

    string namethis;
    string emailthis;
    string passwordthis;

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
    }


    public void LogIn()
    {
        benutzerName.gameObject.SetActive(true);
        passwort.gameObject.SetActive(true);
        //email.gameObject.SetActive(true);
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
      
        if ((PlayerPrefs.GetString("userName" + namethis) != "") )
            Debug.Log("You Logged in with the Username: " + namethis);
        else
            Debug.Log("User not found");
 
        benutzerName.gameObject.SetActive(false);
        email.gameObject.SetActive(false);
        passwort.gameObject.SetActive(false);
        logInDone.gameObject.SetActive(false);
    }

    public void doneSignUp()
    {
        PlayerPrefs.SetString("eMail" + namethis, emailthis);
        PlayerPrefs.SetString("password" + namethis, passwordthis);
        Debug.Log("You Signed up with the Username: " + PlayerPrefs.GetString("userName" + namethis) + "; and the Email: " + PlayerPrefs.GetString("eMail" + namethis));

        benutzerName.gameObject.SetActive(false);
        email.gameObject.SetActive(false);
        passwort.gameObject.SetActive(false);
        signUpDone.gameObject.SetActive(false);
    }
}
