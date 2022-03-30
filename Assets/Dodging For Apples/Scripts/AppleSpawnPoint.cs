using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DodgingForApples
{
    public class AppleSpawnPoint : MonoBehaviour
    {
        public Vector3 SpawnLocation => this.transform.position;
        [ReadOnly] public bool appleAtLocation = false;
    }
}