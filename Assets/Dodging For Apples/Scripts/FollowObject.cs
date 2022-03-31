using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DodgingForApples
{
    public class FollowObject : MonoBehaviour
    {
        [SerializeField, Tooltip("The GameObject to follow.")] private GameObject objectToFollow;
	
        private void LateUpdate()
        {
            gameObject.transform.position = objectToFollow.transform.position;
        }
    }
}