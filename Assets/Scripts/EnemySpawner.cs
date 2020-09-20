using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float secondsBetweenSpawns = 3f;
    [SerializeField] private EnemyMovement enemyPrefab;
    
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }


    private IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            Instantiate(enemyPrefab);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
   
}
