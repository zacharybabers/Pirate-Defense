using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private float globalSpawnFactor = 1f;
    private EnemySpawner[] allSpawners;
    private int waveNumber = 1;
    [SerializeField] private float spawnIncreaseFactor = 1.1f;
    [SerializeField] private float enemiesPerWaveIncreaseFactor = 1.3f;
    [SerializeField] private Text waveText;
    [SerializeField] private Text enemiesText;
    [SerializeField] private PlayerHealth playerHealth;
    public int currentWaveEnemiesLeft = 10;
    void Start()
    {
        allSpawners = FindObjectsOfType<EnemySpawner>();
        SetInitialSpawnFactor();
        waveText.text = "Wave: " + waveNumber;
        enemiesText.text = "Enemies Left: " + currentWaveEnemiesLeft;
    }

    
    void Update()
    {
        SetGlobalSpawnFactor();
        UpdateWaveNumber();
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (playerHealth.hitPoints == 0)
        {
            SceneManager.LoadScene(2);
            if (waveNumber > PlayerPrefs.GetInt("Highscore"))
            {
                {
                    PlayerPrefs.SetInt("Highscore", waveNumber);
                }
            }
        }
    }

    private void SetInitialSpawnFactor()
    {
        foreach (EnemySpawner spawner in allSpawners)
        {
            spawner.spawnFactor = globalSpawnFactor;
        }
    }

    private void SetGlobalSpawnFactor()
    {
        globalSpawnFactor = 1f * Mathf.Pow(spawnIncreaseFactor,waveNumber);
    }

    private void DistributeGlobalSpawnFactor() //Distributes global spawn factor above 1 to each spawner evenly, creating varied gameplay
    {
        var spawnFactorOverhead = globalSpawnFactor - 1;
        var overheadPerSpawner = spawnFactorOverhead / allSpawners.Length;
        foreach (EnemySpawner spawner in allSpawners)
        {
            spawner.spawnFactor = globalSpawnFactor + overheadPerSpawner;
        }


    }
    
    //todo add randomness to distribution of gSF

    private void UpdateWaveNumber()
    {
        if (currentWaveEnemiesLeft == 0)
        {
            var allEnemies = FindObjectsOfType<EnemyDamage>();
            foreach (EnemyDamage enemy in allEnemies)
            {
                Destroy(enemy.gameObject);
            }
            waveNumber++;
            waveText.text = "Wave: " + waveNumber;
            currentWaveEnemiesLeft = Mathf.RoundToInt(10 * Mathf.Pow(enemiesPerWaveIncreaseFactor, waveNumber));
            SetGlobalSpawnFactor();
            DistributeGlobalSpawnFactor();
        }
    }

    public void UpdateEnemiesUI()
    {
        enemiesText.text = "Enemies Left: " + currentWaveEnemiesLeft;
    }
}
