using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DodgingForApples
{
    public class AppleMovement : MonoBehaviour
    {
        [SerializeField] private float timeToCompleteARotation = 1.5f;
        [SerializeField] private float floatingSpeed = 0.2f;
        [SerializeField] private float floatingHeight = 0.4f;
        [SerializeField] private float startingHeight = 0.5f;
        private float appleOriginalHeight;

        private void Start()
        {
            appleOriginalHeight = transform.position.y;
        }

        // Update is called once per frame
        private void Update()
        {
            RotateApple();
            
            MoveAppleUpAndDown();
        }

        private void RotateApple()
        {
            transform.Rotate(Vector3.down, 360f*Time.deltaTime / timeToCompleteARotation);
            
        }

        private void MoveAppleUpAndDown()
        {
            float yPos = Mathf.PingPong(Time.time * floatingSpeed, 1) * floatingHeight;
            transform.position = new Vector3(transform.position.x, yPos + startingHeight + appleOriginalHeight, transform.position.z);
        }
    }
}