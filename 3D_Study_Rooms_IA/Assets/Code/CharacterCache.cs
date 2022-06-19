using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCache : MonoBehaviour
{
    public GameObject thisPlayer;
    GameObject workPlayer = new GameObject();
    GameObject orgWorkPlayer = new GameObject();
    private SkinnedMeshRenderer rendererThis;
    private SkinnedMeshRenderer rendererOrg;

    GameObject tmp = new GameObject();
    public void Awake()
    {
        tmp = GameObject.Instantiate(thisPlayer);
        
    }
    public GameObject cache(GameObject orgPlayer) 
    {

       
        //workPlayer = tmp.transform.GetChild(0).gameObject;
        orgWorkPlayer = orgPlayer.transform.GetChild(0).gameObject;

        //right material
        rendererThis = workPlayer.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();
        rendererOrg = orgWorkPlayer.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();
        rendererThis.material = rendererOrg.material;

        //helmet
        if (orgWorkPlayer.transform.GetChild(3).gameObject.activeInHierarchy)
            workPlayer.transform.GetChild(3).gameObject.SetActive(true);


        //backback
        if (orgWorkPlayer.transform.GetChild(2).gameObject.activeInHierarchy)
            workPlayer.transform.GetChild(2).gameObject.SetActive(true);

        //glasses
        if (orgWorkPlayer.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            workPlayer.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (orgWorkPlayer.transform.GetChild(5).gameObject.activeInHierarchy)
        {
            workPlayer.transform.GetChild(5).gameObject.SetActive(true);
        }

        //instantiate and send ready player back
        //GameObject.Instantiate(thisPlayer);
        return thisPlayer;
    }
}
