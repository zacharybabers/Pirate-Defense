using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int hitPoints = 10;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticlePrefab;

   

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
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }

    void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
        vfx.Play();
        Invoke(nameof(DestroyMe), 0.5f);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
