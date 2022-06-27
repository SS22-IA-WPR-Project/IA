using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInHandler : MonoBehaviour
{

    public Button login;
    public Button signup;
    public Button done;

    public InputField benutzerName;
    public InputField email;
    public InputField passwort;

    bool mode;

    string namethis;
    string emailthis;
    string passwortthis;

    // Start is called before the first frame update
    void Start()
    {
        benutzerName.gameObject.SetActive(false);
        email.gameObject.SetActive(false);
        passwort.gameObject.SetActive(false);
        done.gameObject.SetActive(false);

    }


    public void LogIn()
    {
        benutzerName.gameObject.SetActive(true);
        passwort.gameObject.SetActive(true);
        //email.gameObject.SetActive(true);
        done.gameObject.SetActive(true);

        login.gameObject.SetActive(false);
        signup.gameObject.SetActive(false);

        mode = false;
    }

    public void SignUp()
    {
        benutzerName.gameObject.SetActive(true);
        email.gameObject.SetActive(true);
        passwort.gameObject.SetActive(true);
        done.gameObject.SetActive(true);

        login.gameObject.SetActive(false);
        signup.gameObject.SetActive(false);

        mode = true;

    }

    public void setName(string namenew)
    {
        if (mode)
        {
            namethis = namenew;
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
            passwortthis = passwortnew;

        }
        else
        {
            passwortthis = passwortnew;
        }

    }

    public void Done()
    {
        if (mode)
        {
            Debug.Log("You Signed up with the Username: " + namethis + "; and the Email: " + emailthis);

        }
        else
        {
            Debug.Log("You Logged in with the Username: " + namethis );

        }
        benutzerName.gameObject.SetActive(false);
        email.gameObject.SetActive(false);
        passwort.gameObject.SetActive(false);
        done.gameObject.SetActive(false);
    }
}
