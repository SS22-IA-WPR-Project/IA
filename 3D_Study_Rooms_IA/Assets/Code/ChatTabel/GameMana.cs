using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//neu
using Firesplash.UnityAssets.SocketIO;

namespace Studyrooms
{
    public class GameMana : MonoBehaviour
    {

        private int maxMassnages = 30;

        public GameObject chatPanal;
        public GameObject textObject;
        public InputField chatBox;

        //neu
        private bool listenNewMessage;

        [SerializeField]
        private List<Message> messageList = new List<Message>();

        //neu
        public SocketIOCommunicator socCom;

        //neu wegen sokets
        private void Start()
        {
            listenNewMessage = false;
            string messageFromServer;

            socCom.Instance.On("User: hier bitte Name einfügen", (string data) =>
            {
                messageFromServer = JsonUtility.FromJson<string>(data);
            });
           

            socCom.Instance.Connect("http://35.228.121.222", false);


        }

        //neu
        //private void Update()
        //{
        //   if (listenNewMessage)
        //}

        private void SendMassageToChat(string text)
        {
            if (messageList.Count >= maxMassnages)
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

            chatBox.text = "";
        }

        public void sendButton()
        {
            if (chatBox.text != "")
            {
                //neu
                socCom.Instance.Emit("User: hier bitte Name einfügen", JsonUtility.ToJson(chatBox.text), false);

                SendMassageToChat(chatBox.text);
            }
            //else if (!chatBox.isFocused)
            //{
            //    chatBox.ActivateInputField();
            //}

        }

    }

    [System.Serializable]
    public class Message
    {
        public string text;
        public Text textObject;

    }
}