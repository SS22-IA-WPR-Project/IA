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
        int isIdelHash;
        //int isFrowardRightHash;
        //int isForwardLeftHash;
        //int isForwardBackHash;
        //int isBackwardsRightHash;
        //int isBackwardsLeftHash;

        //private enum WalkingDirection { forward, backwards, right, left, idel }
        //private WalkingDirection previusWalkingDirecktion;
        
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            isWalkingHash = Animator.StringToHash("isWalking");
            isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
            isWalkingRightHash = Animator.StringToHash("isWalkingRight");
            isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
            isIdelHash = Animator.StringToHash("isIdel");
            //isFrowardRightHash = Animator.StringToHash("isFrowardRight");
            //isForwardLeftHash = Animator.StringToHash("isForwardLeft");
            //isForwardBackHash = Animator.StringToHash("isForwardBack");
            //isBackwardsRightHash = Animator.StringToHash("isBackwardsRight");
            //isBackwardsLeftHash = Animator.StringToHash("isBackwardsLeft");

            //previusWalkingDirecktion = WalkingDirection.idel;

        }

        // Update is called once per frame
        void Update()
        {

            bool isWalking = animator.GetBool(isWalkingHash);
            bool isWalkingBackward = animator.GetBool(isWalkingBackwardsHash);
            bool isWalkingRight = animator.GetBool(isWalkingRightHash);
            bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
            bool isIdel = animator.GetBool(isIdelHash);

            //bool isFrowardRight = animator.GetBool(isFrowardRightHash);
            //bool isForwardLeft = animator.GetBool(isForwardLeftHash);
            //bool isForwardBack = animator.GetBool(isForwardBackHash);
            //bool isBackwardsRight = animator.GetBool(isBackwardsRightHash);
            //bool isBackwardsLeft = animator.GetBool(isBackwardsLeftHash);




            bool forwardPressed = (Input.GetKey("up") || Input.GetKey("w"));
            bool backwardPressed = (Input.GetKey("down") || Input.GetKey("s"));
            bool rightPressed = (Input.GetKey("right") || Input.GetKey("d"));
            bool leftPressed = (Input.GetKey("left") || Input.GetKey("a"));

            //Player animation

            if( rightPressed ^ leftPressed)
            {
                animator.SetBool(nameof(isIdel), false);
                animator.SetBool(nameof(isWalking), false);
                animator.SetBool(nameof(isWalkingBackward), false);

                if (rightPressed && !isWalkingRight)
                {

                    animator.SetBool(nameof(isWalkingRight), true);
                    animator.SetBool(nameof(isWalkingLeft), false);
                }
                else if (leftPressed && !isWalkingLeft)
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

                if (forwardPressed && !isWalking)
                {
                    animator.SetBool(nameof(isWalking), true);
                    animator.SetBool(nameof(isWalkingBackward), false);
                }
                else if ( backwardPressed && !isWalkingBackward)
                {
                    animator.SetBool(nameof(isWalking), false);
                    animator.SetBool(nameof(isWalkingBackward), true);
                }
            }
            else if (!isIdel)
            {
                animator.SetBool(nameof(isIdel), true);
            }
                








            ////forward
            //if (!isWalking && forwardPressed)
            //{
            //    animator.SetBool("isWalking", true);
            //}

            //if (isWalking && !forwardPressed)
            //{
            //    animator.SetBool("isWalking", false);
            //}

            ////backward
            //if (!isWalkingBackward && backwardPressed)
            //{
            //    animator.SetBool("isWalkingBackwards", true);
            //}

            //if (isWalkingBackward && !backwardPressed)
            //{
            //    animator.SetBool("isWalkingBackwards", false);
            //}

            ////right
            //if (!isWalkingRight && rightPressed)
            //{
            //    animator.SetBool("isWalkingRight", true);
            //}

            //if (isWalkingRight && ! rightPressed)
            //{
            //    animator.SetBool("isWalkingRight", false);
            //}

            ////left
            //if ( !isWalkingLeft && leftPressed)
            //{
            //    animator.SetBool("isWalkingLeft", true);
            //}

            //if ( isWalkingLeft && !leftPressed)
            //{
            //    animator.SetBool("isWalkingLeft", false);
            //}

            ////diagonalLeft
            //if ((isWalking && forwardPressed) && (!isWalkingLeft && leftPressed))
            //{
            //    animator.SetBool("isForwardLeft", true);
            //}

            //if ((!isWalking && forwardPressed) && (isWalkingLeft && !leftPressed))
            //{
            //    animator.SetBool("isForwardLeft", false);
            //}

            //if ((isWalkingBackward && backwardPressed) && (!isWalkingLeft && leftPressed))
            //{
            //    animator.SetBool("isBackwardsLeft", true);
            //}

            //if ((!isWalkingBackward && backwardPressed) && (isWalkingLeft && !leftPressed))
            //{
            //    animator.SetBool("isBackwardsLeft", false);
            //}

            ////diagonalRight
            //if ((isWalking && forwardPressed) && (!isWalkingRight && rightPressed))
            //{
            //    animator.SetBool("isForwardRight", true);
            //}

            //if ((!isWalking && forwardPressed) && (isWalkingRight && !rightPressed))
            //{
            //    animator.SetBool("isForwardRight", false);
            //}

            //if ((isWalkingBackward && backwardPressed) && (!isWalkingRight && rightPressed))
            //{
            //    animator.SetBool("isBackwardsRight", true);
            //}

            //if ((!isWalkingBackward && backwardPressed) && (isWalkingRight && !rightPressed))
            //{
            //    animator.SetBool("isBackwardsRight", false);
            //}




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