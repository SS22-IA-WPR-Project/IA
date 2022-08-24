using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studyrooms
{
    public class OtherPlayerAnimController : MonoBehaviour
    {
        Animator animator;
        int isWalkingHash;
        int isWalkingBackwardsHash;
        int isWalkingRightHash;
        int isWalkingLeftHash;
        int isIdelHash;

        string checkID;
        string thisID;

        private void Awake()
        {
            SREvents.otherPlayerAnim.AddListener(setID);
        }

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            isWalkingHash = Animator.StringToHash("isWalking");
            isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
            isWalkingRightHash = Animator.StringToHash("isWalkingRight");
            isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
            isIdelHash = Animator.StringToHash("isIdel");

            thisID = transform.root.name; //GetComponentInParent<Transform>().gameObject.GetComponentInParent<Transform>().gameObject.name;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(thisID);
            Debug.Log(checkID);
            if(checkID == thisID)
            {
                bool isWalking = animator.GetBool(isWalkingHash);
                bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
                bool isWalkingRight = animator.GetBool(isWalkingRightHash);
                bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
                bool isIdel = animator.GetBool(isIdelHash);

                bool forwardReceive = PlayerPrefs.GetInt(("up" + checkID)) == 1 ? true : false; // (Input.GetKey("up") || Input.GetKey("w"));
                bool backwardReceive = PlayerPrefs.GetInt(("down" + checkID)) == 1 ? true : false; //(Input.GetKey("down") || Input.GetKey("s"));
                bool rightReceive = PlayerPrefs.GetInt(("right" + checkID)) == 1 ? true : false; // (Input.GetKey("right") || Input.GetKey("d"));
                bool leftReceive = PlayerPrefs.GetInt(("left" + checkID)) == 1 ? true : false; // (Input.GetKey("left") || Input.GetKey("a"));

                Debug.Log("in Controller: " + forwardReceive + " / " + backwardReceive + " / " + rightReceive + " / " + leftReceive);
                //Player animation

                if (rightReceive ^ leftReceive)
                {
                    animator.SetBool(nameof(isIdel), false);
                    animator.SetBool(nameof(isWalking), false);
                    animator.SetBool(nameof(isWalkingBackwards), false);

                    if (rightReceive)
                    {

                        animator.SetBool(nameof(isWalkingRight), true);
                        animator.SetBool(nameof(isWalkingLeft), false);
                    }
                    else
                    {
                        animator.SetBool(nameof(isWalkingRight), false);
                        animator.SetBool(nameof(isWalkingLeft), true);
                    }

                }
                else if (forwardReceive ^ backwardReceive)
                {
                    animator.SetBool(nameof(isIdel), false);
                    animator.SetBool(nameof(isWalkingLeft), false);
                    animator.SetBool(nameof(isWalkingRight), false);

                    if (forwardReceive)
                    {
                        animator.SetBool(nameof(isWalking), true);
                        animator.SetBool(nameof(isWalkingBackwards), false);
                    }
                    else
                    {
                        animator.SetBool(nameof(isWalking), false);
                        animator.SetBool(nameof(isWalkingBackwards), true);

                    }
                }
                else
                {
                    animator.SetBool(nameof(isWalkingLeft), false);
                    animator.SetBool(nameof(isWalkingRight), false);
                    animator.SetBool(nameof(isWalking), false);
                    animator.SetBool(nameof(isWalkingBackwards), false);
                    animator.SetBool(nameof(isIdel), true);
                }
            }

            


        }
        public void setID()
        {
            checkID = SREvents.otherPlayerAnim.GetId();
        }
    }

}

