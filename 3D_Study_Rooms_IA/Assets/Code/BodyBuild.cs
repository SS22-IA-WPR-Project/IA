using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBuild : MonoBehaviour
{
    new SkinnedMeshRenderer renderer;
    public Mesh[] bodybuilds = new Mesh[2];
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SkinnedMeshRenderer>();
       
    }

    public void Bodybuild(float value)
    {
        if(value == 0)
        {
            renderer.sharedMesh = bodybuilds[0];
        }
        else
        {
            renderer.sharedMesh = bodybuilds[1];

        }
        //renderer.SetBlendShapeWeight(1, 100f-value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
