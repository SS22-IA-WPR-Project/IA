using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms
{
    public class CharakterSkin : MonoBehaviour

    {
        new SkinnedMeshRenderer renderer;
        int skin;
        public Material[] skins = new Material[10];

        private void Awake()
        {
            skin = PlayerPrefs.GetInt("skin", 0);
        }

        // Start is called before the first frame update
        void Start()
        {
            renderer = gameObject.GetComponent<SkinnedMeshRenderer>();

            //skins[skins.Length - 1] = renderer.material;
            renderer.material = skins[skin];

        }

        public void next()
        {

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
            PlayerPrefs.SetInt("skin", skin);
            Debug.Log(renderer.material.name);

        }

        public void back()
        {

            if (skin <= 0)
            {
                skin = skins.Length - 1;
            }
            else
            {
                skin--;
            }
            Debug.Log("back " + skin);
            renderer.material = skins[skin];
            PlayerPrefs.SetInt("skin", skin);
            Debug.Log(renderer.material.name);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}