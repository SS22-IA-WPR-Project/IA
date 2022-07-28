using System.Collections;
using System.Collections.Generic;
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


        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            isWalkingHash = Animator.StringToHash("isWalking");
            isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
            isWalkingRightHash = Animator.StringToHash("isWalkingRight");
            isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        }

        // Update is called once per frame
        void Update()
        {

            bool isWalking = animator.GetBool(isWalkingHash);
            bool isWalkingBackward = animator.GetBool(isWalkingBackwardsHash);
            bool isWalkingRight = animator.GetBool(isWalkingRightHash);
            bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);

            bool forwardPressed = (Input.GetKey("up") || Input.GetKey("w"));
            bool backwardPressed = (Input.GetKey("down") || Input.GetKey("s"));
            bool rightPressed = (Input.GetKey("right") || Input.GetKey("d"));
            bool leftPressed = (Input.GetKey("left") || Input.GetKey("a"));

            //Player animation

            //forward
            if (!isWalking && forwardPressed)
            {
                animator.SetBool("isWalking", true);
            }

            if (isWalking && !forwardPressed)
            {
                animator.SetBool("isWalking", false);
            }

            //backward
            if (!isWalkingBackward && backwardPressed)
            {
                animator.SetBool("isWalkingBackwards", true);
            }

            if (isWalkingBackward && !backwardPressed)
            {
                animator.SetBool("isWalkingBackwards", false);
            }

            //right
            if (!isWalkingRight && rightPressed)
            {
                animator.SetBool("isWalkingRight", true);
            }

            if (isWalkingRight && ! rightPressed)
            {
                animator.SetBool("isWalkingRight", false);
            }

            //left
            if ( !isWalkingLeft && leftPressed)
            {
                animator.SetBool("isWalkingLeft", true);
            }

            if ( isWalkingLeft && !leftPressed)
            {
                animator.SetBool("isWalkingLeft", false);
            }
        }

        /*if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

        }*/

    }
}