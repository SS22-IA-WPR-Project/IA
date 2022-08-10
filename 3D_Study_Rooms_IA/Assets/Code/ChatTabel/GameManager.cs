using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int maxMassnages = 30;

    public GameObject chatPanal;
    public GameObject textObject;
    public InputField chatBox;

    [SerializeField] 
    private List<Message> messageList = new List<Message>();


    void Start()
    {
        
    }

   
    void Update()
    {
        if(chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMassageToChat(chatBox.text);
                chatBox.text = "";

            }
        }
        else
        {
            if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
                
            }

        }



        if(!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
            SendMassageToChat("SpachKey is pressed");
                Debug.Log("Space");

            }

        }
        

        
    }

    public void SendMassageToChat(string text) 
    {
        if(messageList.Count >= maxMassnages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMassage = new Message();

        newMassage.text = text;

        GameObject newText = Instantiate(textObject, chatPanal.transform);

        newMassage.textObject = newText.GetComponent<Text>();
        newMassage.textObject.text = newMassage.text;

        messageList.Add(newMassage);

    }
    
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;

}