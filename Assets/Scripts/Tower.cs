using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private Transform targetEnemy;
    [SerializeField] private ParticleSystem projectileParticle;
    
    void Update()
    {
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
