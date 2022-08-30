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
            //assigns the correct animations to the corresponding variable
            animator = GetComponent<Animator>();
            isWalkingHash = Animator.StringToHash("isWalking");
            isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
            isWalkingRightHash = Animator.StringToHash("isWalkingRight");
            isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
            isIdelHash = Animator.StringToHash("isIdel");

            thisID = transform.root.name;
        }

        // Update is called once per frame
        void Update()
        {
            if(checkID == thisID)
            {
                bool isWalking = animator.GetBool(isWalkingHash);
                bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
                bool isWalkingRight = animator.GetBool(isWalkingRightHash);
                bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
                bool isIdel = animator.GetBool(isIdelHash);

                bool forwardReceive = PlayerPrefs.GetInt(("up" + checkID)) == 1 ? true : false;
                bool backwardReceive = PlayerPrefs.GetInt(("down" + checkID)) == 1 ? true : false;
                bool rightReceive = PlayerPrefs.GetInt(("right" + checkID)) == 1 ? true : false;
                bool leftReceive = PlayerPrefs.GetInt(("left" + checkID)) == 1 ? true : false;

                //OtherPlayer animation

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
            checkID = SREvents.otherPlayerAnim.getId();
        }
    }
}

