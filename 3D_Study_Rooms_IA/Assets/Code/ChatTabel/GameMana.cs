using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Studyrooms
{
    public class GameMana : MonoBehaviour
    {

        private int maxMassnages = 30;

        public GameObject chatPanal;
        public GameObject textObject;
        public InputField chatBox;

        [SerializeField]
        private List<Message> messageList = new List<Message>();

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
                SendMassageToChat(chatBox.text);
            }
            else if (!chatBox.isFocused)
            {
                chatBox.ActivateInputField();
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