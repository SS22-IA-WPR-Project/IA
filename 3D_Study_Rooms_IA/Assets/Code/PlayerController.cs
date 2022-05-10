using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schlaffner_Andre {
	public class PlayerController : MonoBehaviour
	{
        private GameObject PlayerPosition;
        // Start is called before the first frame update

        //TODO:
        //
        //Camera setup and control for players
        //
        //GUI
        //
        //Emoticon Table reference
        //
        //interaction with other Players reference
        //
        //(voice) chat reference
        //
        //Whiteboard/text projecting reference
        //

        void Start()
        {
            PlayerPosition = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            //Player movement

            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                PlayerPosition.transform.localPosition += Time.deltaTime * PlayerPosition.transform.forward * 2f;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                PlayerPosition.transform.Rotate(-PlayerPosition.transform.up * 0.5f);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                PlayerPosition.transform.localPosition += Time.deltaTime * -PlayerPosition.transform.forward * 2f;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                PlayerPosition.transform.Rotate(PlayerPosition.transform.up * 0.5f);
            }
        }
    }
}