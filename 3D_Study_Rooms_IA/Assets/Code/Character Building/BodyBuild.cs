using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Studyrooms
{
    public class BodyBuild : MonoBehaviour
    {
        new SkinnedMeshRenderer renderer;
        public Mesh[] bodybuilds = new Mesh[2];

        float bodyValue;

        public Slider slider;

        private void Awake()
        {
            bodyValue = PlayerPrefs.GetFloat("bodyValue", 0);
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
                PlayerPrefs.SetFloat("bodyValue", value);
            }
            else
            {
                renderer.sharedMesh = bodybuilds[(int)value];
                PlayerPrefs.SetFloat("bodyValue", value);

            }
            //renderer.SetBlendShapeWeight(1, 100f-value);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}