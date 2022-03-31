using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DodgingForApples
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 InputVector { get; private set; }

        public Vector3 MousePosition { get; private set; }
        
        // The Animator.
        public Animator myAnim;

        private void Start()
        {
            myAnim = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            InputVector = new Vector2(h, v);

            if(InputVector.magnitude >= 0.1) // If there is no movement input.
                myAnim.SetFloat("Speed",1);
            else
                myAnim.SetFloat("Speed",0);
            MousePosition = Input.mousePosition;
        }
    }
}