using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AccessoriesCharacter : MonoBehaviour
{
    GameObject backpack;
    GameObject helmet;
    GameObject glasses1;
    GameObject glasses2;

    Dropdown drop;

    // Start is called before the first frame update
    void Start()
    {
        //load to the right var and deactivate the accessories for the start 

        backpack = gameObject.transform.GetChild(2).gameObject;
        helmet = gameObject.transform.GetChild(3).gameObject;
        glasses1 = gameObject.transform.GetChild(4).gameObject;
        glasses2 = gameObject.transform.GetChild(5).gameObject;


        backpack.SetActive(false);
        helmet.SetActive(false);
        //glasses1.SetActive(false);
        //glasses2.SetActive(false);

        //drop = Dropdown.fii Find("Dropdown");
        drop = GameObject.FindObjectOfType<Dropdown>();
        glasses(drop.value);

    }

    public void backpackActive(bool state)
    {
        backpack.SetActive(state);
    }

    public void helmetActive(bool state)
    {
        helmet.SetActive(state);
    }

    public void glasses(float value)
    {
        
        //Debug.Log(value);
        switch (value)
        {
            case 0:
                glasses1.SetActive(false);
                glasses2.SetActive(false);
                break;
            case 1:
                glasses1.SetActive(true);
                glasses2.SetActive(false);
                break;
            case 2:
                glasses1.SetActive(false);
                glasses2.SetActive(true);
                break;
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        //the switch case for the glasses gets constantly called with this value of the selected collom; so the right glasses are on the character 
        glasses(drop.value);
    }
}
