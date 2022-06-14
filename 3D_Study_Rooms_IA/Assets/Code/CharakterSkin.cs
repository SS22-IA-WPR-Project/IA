using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterSkin : MonoBehaviour

{
    new SkinnedMeshRenderer renderer;
    int skin = -1;
    public Material[] skins = new Material[10];

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SkinnedMeshRenderer>();
        Debug.Log(renderer.material.name);
        skins[skins.Length - 1] = renderer.material;

        
    }

    public void next() {

        if (skin == skins.Length - 1)
        {
            skin = 0;
        }
        else
        {
            skin++;
        }

        Debug.Log("next " + skin);
        renderer.material = skins[skin];
        
        Debug.Log(renderer.material.name);
        
    }

    public void back()
    {

        if (skin <= 0)
        {
            skin = skins.Length-1;
        }
        else
        {
            skin--;
        } 
        Debug.Log("back " + skin);
        renderer.material = skins[skin];
       
        Debug.Log(renderer.material.name);
        /*
        if (skin == 0)
        {
            skin = skins.Length;
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
