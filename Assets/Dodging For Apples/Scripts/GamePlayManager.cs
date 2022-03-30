using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DodgingForApples
{
    public class GamePlayManager : MonoBehaviour
    {
        [ReadOnly] public bool gameOver = false;
        // Start is called before the first frame update
        private void Start()
        {
            gameOver = false;
        }
    }
}