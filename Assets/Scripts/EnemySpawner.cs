using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [Range(0.1f, 120f)]
    [SerializeField] private float secondsBetweenSpawns = 3f;
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private Transform enemyParentTransform;
    [SerializeField] private Text scoreText;
    private int score = 0;
    
    void Start()
    {
        scoreText.text = "Score: " + score;
        StartCoroutine(RepeatedlySpawnEnemies());
    }


    private IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            score++;
            scoreText.text = "Score: " + score;            
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
   
}
