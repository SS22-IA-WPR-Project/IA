using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    public GameObject backpack;
    public GameObject helmet;
    public GameObject glasses1;
    public GameObject glasses2;
    public Mesh[] bodybuilds = new Mesh[2];

    new SkinnedMeshRenderer renderer;

    int backpackOn;
    int helmetOn;
    int glassesOn;
    float bodyValue;

    private void Awake()
    {
        backpackOn = PlayerPrefs.GetInt("backpack", 0);
        helmetOn = PlayerPrefs.GetInt("helmet", 0);
        glassesOn = PlayerPrefs.GetInt("glasses", 0);
        bodyValue = PlayerPrefs.GetFloat("bodyValue", 0);

    }

    // Start is called before the first frame update
    void Start()
    {
        //glasses
        glasses(glassesOn);
       
        //backpack
        backpackActive(backpackOn == 1 ? true : false);
       
        //helmet
        helmetActive(helmetOn == 1 ? true : false);
        
        //bodybuild
        renderer = gameObject.GetComponent<SkinnedMeshRenderer>();
        Bodybuild(bodyValue);
    }

    public void backpackActive(bool state)
    {
        backpack.SetActive(state);
    }

    public void helmetActive(bool state)
    {
        helmet.SetActive(state);
    }

    public void glasses(int value)
    {
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
    public void Bodybuild(float value)
    {
        if (value == 0)
        {
            renderer.sharedMesh = bodybuilds[(int)value];
        }
        else
        {
            renderer.sharedMesh = bodybuilds[(int)value];
        }

    }


}
