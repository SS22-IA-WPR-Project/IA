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

            renderer.material = skins[skin];
            PlayerPrefs.SetInt("skin", skin);
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
            renderer.material = skins[skin];
            PlayerPrefs.SetInt("skin", skin);
        }
    }
}