using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SeekerBullet : MonoBehaviour
{
    private EnemyController[] activeEnemies;
    private float[] enemiesDistances;
    private bool seekEnemy = false;
    private Transform targetEnemy;
    private Rigidbody bulletRigidBody;
    private int seekingSpeed = 10;
    private void OnEnable()
    {
        if (bulletRigidBody == null)
            bulletRigidBody = GetComponent<Rigidbody>();
        FindNearestEnemy();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (seekEnemy)
        {
            if (targetEnemy != null)
            {
                var direction = targetEnemy.position - transform.position;
                direction.Normalize();
                bulletRigidBody.velocity = direction * seekingSpeed;
            }
            else
                FindNearestEnemy();
        }
    }
    private void FindNearestEnemy()
    {
        activeEnemies = FindObjectsOfType<EnemyController>();
        CalculateDistances(activeEnemies);
        var nearestindex = Array.IndexOf(enemiesDistances, enemiesDistances.Min());
        targetEnemy = activeEnemies[nearestindex].transform;
        seekEnemy = true;
    }
    private void CalculateDistances(EnemyController[] enemies)
    {
        if (enemies.Length > 0)
        {
            enemiesDistances = new float[enemies.Length];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemiesDistances[i] = Vector3.Distance(enemies[i].transform.position, transform.position);
            }
        }
    }

    private void OnDisable()
    {
        seekEnemy = false;
    }
}
