using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class CharacterCache : MonoBehaviour
{
    public GameObject thisPlayer;
    public Mesh[] bodyBuilds = new Mesh[2];
    public Material[] skins;

     
    private SkinnedMeshRenderer rendererThis = new SkinnedMeshRenderer();
    
    GameObject tmp;
    GameObject backpack;
    GameObject helmet;
    GameObject glasses1;
    GameObject glasses2;

    public void Awake()
    {
        //instantiate player for new scene
        //tmp = GameObject.Instantiate(thisPlayer);
        Debug.Log(PlayerPrefs.GetInt("skin"));
        
        //rendererThis = thisPlayer.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();
        //rendererThis = thisPlayer.transform.GetChild(0).gameObject.transform.GetComponentInChildren(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer;

        //these wont work with the new structur in hierarchy in the prefab
        helmet = thisPlayer.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
        backpack = tmp.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
        glasses1 = tmp.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
        glasses2 = tmp.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject;
        
    }
    public GameObject cache() 
    {

        Debug.Log(thisPlayer);
        //right material
        //rendererThis.material = skins[PlayerPrefs.GetInt("skin")];

        
        //helmet
        if (PlayerPrefs.GetInt("helmet") == 1 ? true : false)
        {
            Debug.Log(1);
            helmet.SetActive(true);
        }
        else
        {
            helmet.SetActive(false);
        }
         
       
        //backback
        if (PlayerPrefs.GetInt("backpack") == 1 ? true : false)
        { 
            Debug.Log(2);
            backpack.SetActive(true);
        }
        else
        {
            backpack.SetActive(false);
        }
            
        Debug.Log(3);
        //glasses
        switch (PlayerPrefs.GetInt("glasses"))
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

        Debug.Log(4);
        //bodybuild
        //rendererThis.sharedMesh = bodyBuilds[PlayerPrefs.GetInt("bodyValue")];
        Debug.Log(5);
        //send ready player back
        return thisPlayer;
    }
}
*/