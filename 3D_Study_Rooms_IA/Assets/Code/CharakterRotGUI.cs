using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterRotGUI : MonoBehaviour
{
    private GameObject charaRot;
    // Start is called before the first frame update
    void Start()
    {
        //charaRot = GameObject.Find("Player");
        charaRot = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) )
        {
            charaRot.transform.Rotate(-charaRot.transform.up * 0.5f);
        }
        if (Input.GetKey(KeyCode.E) )
        {
            charaRot.transform.Rotate(charaRot.transform.up * 0.5f);
        }

    }

    
}
