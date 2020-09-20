using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Range(0.1f, 120f)]
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
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
   
}
