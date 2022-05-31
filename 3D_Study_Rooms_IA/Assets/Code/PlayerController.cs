using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schlaffner_Andre {
	public class PlayerController : MonoBehaviour
	{
        private GameObject PlayerPosition;
        private GameObject Player;
        // Start is called before the first frame update

        //TODO:
        //
        //Camera control for players (?)
        //
        //Emoticon Table reference
        //
        //interaction with other Players keys
        //
        //(voice) chat keys
        //
        //Whiteboard/text projecting keys
        //

        void Start()
        {
            PlayerPosition = GameObject.Find("Player");
            //PlayerPosition = this.gameObject;
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