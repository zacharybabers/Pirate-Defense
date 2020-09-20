using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters of each tower
    [SerializeField] private Transform objectToPan;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private ParticleSystem projectileParticle;
    // State of the tower
    private Transform targetEnemy;
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            LookAtEnemy();
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;

    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemy)
    {
        if (Vector3.Distance(closestEnemy.position, transform.position) <=
            Vector3.Distance(testEnemy.position, transform.position))
        {
            return closestEnemy;
        }
        return (testEnemy);
        }

    private void LookAtEnemy()
    {
        objectToPan.LookAt((targetEnemy));
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
