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
            SpawnAllApples();
        }

        private void SpawnAllApples()
        {
            for(int i = 0; i < maxNumberOfApples; i++)
            {
                   SpawnApple();
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
            
            print($"randomVacantAppleSpawnPoint = {randomVacantAppleSpawnPoint}");
            Instantiate(applePrefab, appleSpawnPoints[randomVacantAppleSpawnPoint].SpawnLocation, Quaternion.identity);
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