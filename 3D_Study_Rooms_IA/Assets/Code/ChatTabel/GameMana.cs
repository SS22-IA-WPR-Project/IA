using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firesplash.UnityAssets.SocketIO;

namespace Studyrooms
{
    public class GameMana : MonoBehaviour
    {

        private int maxMassnages = 30;

        public GameObject chatPanal;
        public GameObject textObject;
        public InputField chatBox;
        public SocketIOCommunicator socCom;
        private bool connected;

        [SerializeField]
        private List<Message> messageList = new List<Message>();

        private void Start()
        {
            string messageFromServer;
            connected = false;
            socCom.Instance.On("connection", (string data) =>
            {
                connected = true;
                messageFromServer = JsonUtility.FromJson<string>(data);
                SendMassageToChat(messageFromServer);
            });

            socCom.Instance.On("sendMessage", (string data) =>
            {
                messageFromServer = JsonUtility.FromJson<string>(data);
                SendMassageToChat(messageFromServer);
            });

            socCom.Instance.On("message", (string data) =>
            {
                messageFromServer = JsonUtility.FromJson<string>(data);
                SendMassageToChat(messageFromServer);
            });

            socCom.Instance.Connect("http://3dstudyrooms.social/chat-services", false);
        }

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
                if (connected)
                {
                    socCom.Instance.Emit("sendMessage", JsonUtility.ToJson(chatBox.text), false);

                }
                
                SendMassageToChat(chatBox.text);
            }
        }
    }

    [System.Serializable]
    public class Message
    {
        public string text;
        public Text textObject;
    }
}