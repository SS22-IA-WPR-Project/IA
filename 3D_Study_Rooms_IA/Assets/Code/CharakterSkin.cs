using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterSkin : MonoBehaviour

{
    new SkinnedMeshRenderer renderer;
    int skin = 0;
    public Material[] skins = new Material[4];

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SkinnedMeshRenderer>();
        Debug.Log(renderer.material.name);

        
    }

    public void next() {
        
        renderer.material =skins[skin];
        
        Debug.Log(renderer.material.name);
        
       if(skin == 3)
        {
            skin = 0;
        }
        else
        {
            skin++;
        }
       

    }

    public void back()
    {   
        
        renderer.material = skins[skin];
       
        Debug.Log(renderer.material.name);

        if (skin == 0)
        {
            skin = 3;
        }
        else
        {
            skin--;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
