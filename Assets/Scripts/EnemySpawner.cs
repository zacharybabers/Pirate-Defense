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
    [SerializeField] private AudioClip spawnedEnemySFX;
    private int score = 0;
    private AudioSource myAudioSource;
    
    void Start()
    {
        scoreText.text = "Score: " + score;
        myAudioSource = GetComponent<AudioSource>();
        StartCoroutine(RepeatedlySpawnEnemies());
    }


    private IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            AddScore();
            myAudioSource.PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
