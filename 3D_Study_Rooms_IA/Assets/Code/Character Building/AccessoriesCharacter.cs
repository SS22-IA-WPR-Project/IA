using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Studyrooms
{
    public class AccessoriesCharacter : MonoBehaviour
    {
        public GameObject backpack;
        public GameObject helmet;
        public GameObject glasses1;
        public GameObject glasses2;

        public Dropdown drop;
        public Toggle backpackToggle;
        public Toggle helmetToggel;

        int backpackOn;
        int helmetOn;
        int glassesOn;


        private void Awake()
        {
            backpackOn = PlayerPrefs.GetInt("backpack", 0);
            helmetOn = PlayerPrefs.GetInt("helmet", 0);
            glassesOn = PlayerPrefs.GetInt("glasses", 0);

        }

        // Start is called before the first frame update
        void Start()
        {
            //load to the right var and deactivate the accessories for the start 

            //helmet = gameObject.transform.GetChild(2).gameObject;
            //backpack = gameObject.transform.GetChild(3).gameObject;
            //glasses1 = gameObject.transform.GetChild(4).gameObject;
            //glasses2 = gameObject.transform.GetChild(5).gameObject;

            //proper setup for the glasses dropdown. 
            //first line of the might need to be changed latter if more Dropdowns are in project
            //drop = GameObject.FindObjectOfType<Dropdown>();
            drop.onValueChanged.AddListener(delegate
            {
                DropdownValueChanged(drop);
            });

            //using the Playerprefs to set up the player from last session

            //glasses
            glasses(glassesOn);
            drop.SetValueWithoutNotify(glassesOn);

            //backpack
            backpackActive(backpackOn == 1 ? true : false);
            backpackToggle.isOn = backpackOn == 1 ? true : false;

            //helmet
            helmetActive(helmetOn == 1 ? true : false);
            helmetToggel.isOn = helmetOn == 1 ? true : false;
        }

        private void DropdownValueChanged(Dropdown drop)
        {
            glasses(drop.value);

        }

        public void backpackActive(bool state)
        {
            backpack.SetActive(state);
            PlayerPrefs.SetInt("backpack", state ? 1 : 0);

            Debug.Log("backpack" + PlayerPrefs.GetInt("backpack"));

        }

        public void helmetActive(bool state)
        {
            helmet.SetActive(state);
            PlayerPrefs.SetInt("helmet", state ? 1 : 0);

            Debug.Log("helmet" + PlayerPrefs.GetInt("helmet"));
        }

        public void glasses(int value)
        {

            //Debug.Log(PlayerPrefs.GetInt("glasses", value));
            switch (value)
            {
                case 0:
                    glasses1.SetActive(false);
                    glasses2.SetActive(false);
                    PlayerPrefs.SetInt("glasses", value);
                    break;
                case 1:
                    glasses1.SetActive(true);
                    glasses2.SetActive(false);
                    PlayerPrefs.SetInt("glasses", value);
                    break;
                case 2:
                    glasses1.SetActive(false);
                    glasses2.SetActive(true);
                    PlayerPrefs.SetInt("glasses", value);
                    break;

            }
        }

    }
}