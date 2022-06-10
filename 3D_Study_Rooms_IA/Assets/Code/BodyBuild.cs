using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBuild : MonoBehaviour
{
    new SkinnedMeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SkinnedMeshRenderer>();
       
    }

    public void Bodybuild(float value)
    {
        renderer.SetBlendShapeWeight(0, value);
        renderer.SetBlendShapeWeight(1, 100f-value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
