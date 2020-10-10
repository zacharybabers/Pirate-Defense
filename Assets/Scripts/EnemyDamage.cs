using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int hitPoints = 10;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticlePrefab;
    [SerializeField] private AudioClip damageSFX;

    [SerializeField] private AudioClip enemyDeathSFX;
    private AudioSource myAudioSource;
    private Camera mainCamera;
    private GameStateManager gameState;


    private void Start()
    {
        gameState = FindObjectOfType<GameStateManager>();
        myAudioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;
    }
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        PlayDamageSound();
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }

    void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
        vfx.Play();
        Invoke(nameof(DestroyMe), 0.5f);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, mainCamera.transform.position, 1f);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
        gameState.currentWaveEnemiesLeft--;
        gameState.UpdateEnemiesUI();
    }

    private void PlayDamageSound()
    {
        myAudioSource.PlayOneShot(damageSFX, 0.5f);
    }
}
