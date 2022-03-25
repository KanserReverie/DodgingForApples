using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DodgingForApples
{
    public class FoxAI : MonoBehaviour
    {
        [SerializeField] private GameObject playerToChase;
        [SerializeField] private GameObject gameOverText;
        [SerializeField] private NavMeshAgent foxAI;

        private void Start()
        {
            gameOverText.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            foxAI.SetDestination(playerToChase.transform.position);
        }

        private void OnCollisionStay(Collision other)
        {
            if(other.gameObject == playerToChase)
                gameOverText.SetActive(true);
        }
    }
}