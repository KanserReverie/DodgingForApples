using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DodgingForApples
{
    public class AppleManager : MonoBehaviour
    {
        [SerializeField, ReadOnly] private AppleSpawnPoint[] appleSpawnPoints;
        [SerializeField] private int maxNumberOfApples = 3;
        [SerializeField, ReadOnly] private int numberOfApplesInScene = 0;
        [SerializeField] private GameObject applePrefab;

        private void OnValidate()
        {
            Refresh_appleSpawnPoints();
            Check_maxNumberOfApples_IsntTooLarge();
        }

        // Start is called before the first frame update
        private void Start()
        {
            Refresh_appleSpawnPoints();
            Check_maxNumberOfApples_IsntTooLarge();
            SpawnMaxNumberOfApples();
            InvokeRepeating(nameof(SpawnMaxNumberOfApples), 5,2);
        }

        private void SpawnMaxNumberOfApples()
        {
            if(numberOfApplesInScene < maxNumberOfApples)
            {
                while(numberOfApplesInScene < maxNumberOfApples)
                {
                    SpawnApple();
                    numberOfApplesInScene++;
                }
                Debug.Log("Apples Spawned In");
            }
            else
            {
                Debug.Log("No Apples Need to be spawned");
            }
        }

        private void SpawnApple()
        {
            if(applePrefab == null) {
                 Debug.LogWarning("Sorry, no Apple Prefab to Spawn"); return; }
            
            List<int> vacentAppleSpawnPointIndexs = new List<int>();
            vacentAppleSpawnPointIndexs = CheckVacentSpawnPoints();

            if(vacentAppleSpawnPointIndexs == null) {
                Debug.LogWarning("Sorry, no vacant Apple Spawn Points."); return; }
            
            int randomVacantAppleSpawnPoint = vacentAppleSpawnPointIndexs[Random.Range(0, vacentAppleSpawnPointIndexs.Count)];

            SpawnAppleAt(randomVacantAppleSpawnPoint);
        }

        private void SpawnAppleAt(int _AppleSpawnPoint)
        {
            GameObject appleSpawnedIn = Instantiate(applePrefab, appleSpawnPoints[_AppleSpawnPoint].SpawnLocation, Quaternion.identity);
            Apple appleMade = appleSpawnedIn.GetComponent(typeof(Apple)) as Apple;
            appleMade.appleSpawnPointIndex = _AppleSpawnPoint;
            appleMade.spawnPoint = appleSpawnPoints[_AppleSpawnPoint].gameObject;
            appleSpawnPoints[_AppleSpawnPoint].appleAtLocation = true;
        }

        private List<int> CheckVacentSpawnPoints()
        {
            List<int> spawnPointIndexs = new List<int>();
            for(int i = 0; i < appleSpawnPoints.Length; i++)
            {
                if(!appleSpawnPoints[i].appleAtLocation)
                {
                    spawnPointIndexs.Add(i);
                }
            }

            return spawnPointIndexs;
        }

        private void Check_maxNumberOfApples_IsntTooLarge() 
        {
            if(appleSpawnPoints != null && maxNumberOfApples > appleSpawnPoints.Length)
                maxNumberOfApples = appleSpawnPoints.Length;
        }

        private void Refresh_appleSpawnPoints() => appleSpawnPoints = FindObjectsOfType(typeof(AppleSpawnPoint)) as AppleSpawnPoint[];

    }
}