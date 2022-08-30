using UnityEngine;


namespace Studyrooms
{
    public class PlayerAnimationController : MonoBehaviour
    {
        Animator animator;
        int isWalkingHash;
        int isWalkingBackwardsHash;
        int isWalkingRightHash;
        int isWalkingLeftHash;
        int isIdelHash;        
        
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
        }

        // Update is called once per frame
        void Update()
        {

            bool isWalking = animator.GetBool(isWalkingHash);
            bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
            bool isWalkingRight = animator.GetBool(isWalkingRightHash);
            bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
            bool isIdel = animator.GetBool(isIdelHash);

            bool forwardPressed = (Input.GetKey("up") || Input.GetKey("w"));
            bool backwardPressed = (Input.GetKey("down") || Input.GetKey("s"));
            bool rightPressed = (Input.GetKey("right") || Input.GetKey("d"));
            bool leftPressed = (Input.GetKey("left") || Input.GetKey("a"));

            //Player animation

            if( rightPressed ^ leftPressed)
            {
                animator.SetBool(nameof(isIdel), false);
                animator.SetBool(nameof(isWalking), false);
                animator.SetBool(nameof(isWalkingBackwards), false);

                if (rightPressed )
                {
                    animator.SetBool(nameof(isWalkingRight), true);
                    animator.SetBool(nameof(isWalkingLeft), false);
                }
                else 
                {
                    animator.SetBool(nameof(isWalkingRight),false);
                    animator.SetBool(nameof(isWalkingLeft), true);
                }

            }
            else if( forwardPressed ^ backwardPressed)
            {
                animator.SetBool(nameof(isIdel), false);
                animator.SetBool(nameof(isWalkingLeft), false);
                animator.SetBool(nameof(isWalkingRight), false);

                if (forwardPressed )
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
}