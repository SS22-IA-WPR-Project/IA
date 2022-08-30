using UnityEngine;
using UnityEngine.UI;

namespace Studyrooms { 
    public class ToChangeAvatar : MonoBehaviour
    {   
        GameObject activeplayer;
        public Camera AvatarCamera0;

        public Button next;
        public Button back;
        public Button save;
        public Button leave;

        public Toggle backpack;
        public Toggle helmet;

        public Slider bodybuild;
        public Dropdown glasses;


        private void Awake()
        {
            SREvents.sceneLoadClassToGUI.AddListener(classToCharGUI);
        }

        public void classToCharGUI()
        {
            next.GetComponent<Image>().raycastTarget = true;
            back.GetComponent<Image>().raycastTarget = true;
            save.GetComponent<Image>().raycastTarget = true;
            leave.GetComponent<Image>().raycastTarget = true;
            glasses.GetComponent<Image>().raycastTarget = true;

            backpack.GetComponentInChildren<Image>().raycastTarget = true;
            helmet.GetComponentInChildren<Image>().raycastTarget = true;
            bodybuild.GetComponentInChildren<Image>().raycastTarget = true;

            activeplayer = GameObject.Find(PlayerPrefs.GetString("playerID"));
            activeplayer.GetComponent<PlayerController>().enabled = false;
            activeplayer.GetComponentInChildren<Camera>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            AvatarCamera0.enabled = true;
        }

        public void leaveChangingRoom()
        {
            AvatarCamera0.enabled = false;
            
            next.GetComponent<Image>().raycastTarget = false;
            back.GetComponent<Image>().raycastTarget = false;
            save.GetComponent<Image>().raycastTarget = false;
            leave.GetComponent<Image>().raycastTarget = false;
            glasses.GetComponent<Image>().raycastTarget = false;

            backpack.GetComponentInChildren<Image>().raycastTarget = false;
            helmet.GetComponentInChildren<Image>().raycastTarget = false;
            bodybuild.GetComponentInChildren<Image>().raycastTarget = false;

            SREvents.sceneLoadClass.Invoke();
            SREvents.reloadAvatar.Invoke();
        }       
    }
}
