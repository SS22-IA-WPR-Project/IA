using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class PlayerAnimationController : MonoBehaviour
    {
        
    Animator animator;
    int isWalkingHash;



        // Start is called before the first frame update
        void Start()
        {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        }

        // Update is called once per frame
        void Update()
        {

        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = (Input.GetKey("up") || Input.GetKey("w"));
            //Player animation

            if (!isWalking && forwardPressed)
            {
                animator.SetBool("isWalking", true);
            
            }

            if (isWalking && !forwardPressed)
            {
                animator.SetBool("isWalking", false);
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
