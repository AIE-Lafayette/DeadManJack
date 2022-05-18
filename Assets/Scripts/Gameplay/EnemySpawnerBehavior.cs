using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private EnemyBehavior _enemy;
    [SerializeField]
    private Transform _enemyTarget;
    private GameManagerBehavior _gameManager;

    public void SpawnEnemy()
    {
        float randX = Random.Range(-5000, 5000);
        Vector3 randSpawn = new Vector3(randX / 1000, 0, transform.position.z);
        EnemyBehavior spawnedEnemy = Instantiate(_enemy, randSpawn, transform.rotation);
        spawnedEnemy.GameManager = _gameManager;
    }
}
