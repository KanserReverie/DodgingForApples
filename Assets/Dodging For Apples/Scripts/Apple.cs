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
    }
}