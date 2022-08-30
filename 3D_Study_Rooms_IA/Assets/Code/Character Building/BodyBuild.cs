using UnityEngine;
using UnityEngine.UI;

namespace Studyrooms
{
    public class BodyBuild : MonoBehaviour
    {
        new SkinnedMeshRenderer renderer;
        public Mesh[] bodybuilds = new Mesh[2];

        int bodyValue;

        public Slider slider;

        private void Awake()
        {
            bodyValue = PlayerPrefs.GetInt("bodyValue", 0);
        }

        // Start is called before the first frame update
        void Start()
        {
            renderer = gameObject.GetComponent<SkinnedMeshRenderer>();
            Bodybuild(bodyValue);
            slider.SetValueWithoutNotify(bodyValue);
        }

        public void Bodybuild(float value)
        {
            if (value == 0)
            {
                renderer.sharedMesh = bodybuilds[(int)value];
                PlayerPrefs.SetInt("bodyValue", (int)value);
            }
            else
            {
                renderer.sharedMesh = bodybuilds[(int)value];
                PlayerPrefs.SetInt("bodyValue", (int)value);

            }
        }  
    }
}