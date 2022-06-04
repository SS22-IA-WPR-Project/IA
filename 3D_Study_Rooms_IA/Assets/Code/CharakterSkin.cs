using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterSkin : MonoBehaviour

{
    SkinnedMeshRenderer renderer;
    int skin = 1;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SkinnedMeshRenderer>();

        
    }

    public void next() {

        renderer.material = renderer.materials[skin];
        skin++;
        
    
    }

    public void back()
    {
        renderer.material = renderer.materials[skin];
        skin--;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
