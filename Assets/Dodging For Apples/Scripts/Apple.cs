using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DodgingForApples
{
    public class Apple : MonoBehaviour
    {
        [ReadOnly] public int appleSpawnPointIndex;
        [ReadOnly] public GameObject spawnPoint;

        private void OnCollisionStay(Collision collision)
        {
            if(collision.transform.tag == "Player")
            {
                collision.gameObject.GetComponentInChildren<Player>();
            }
        }
    }
}