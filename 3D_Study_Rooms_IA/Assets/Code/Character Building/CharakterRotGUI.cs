using UnityEngine;

namespace Studyrooms
{
    public class CharakterRotGUI : MonoBehaviour
    {
        private GameObject charaRot;
        // Start is called before the first frame update
        void Start()
        {
            charaRot = this.gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                charaRot.transform.Rotate(charaRot.transform.up * 0.5f);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                charaRot.transform.Rotate(-charaRot.transform.up * 0.5f);
            }
        }
    }
}